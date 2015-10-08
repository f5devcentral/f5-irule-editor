using System;
using System.Collections.Generic;
using System.Text;

namespace iRuler.Utility
{
	public class FileTransfer
	{
		public static string downloadFile(iControl.Interfaces interfaces, string remote_file)
		{
			long chunk_size = 64 * 1024;
			long file_offset = 0;
			bool bContinue = true;
			string file_contents = "";
			System.IO.StringWriter sw = new System.IO.StringWriter();
			if (interfaces.initialized)
			{
				iControl.SystemConfigSyncFileTransferContext ftc = new iControl.SystemConfigSyncFileTransferContext();
				while (bContinue)
				{
					ftc = interfaces.SystemConfigSync.download_file(remote_file, chunk_size, ref file_offset);
					file_contents += System.Text.ASCIIEncoding.ASCII.GetString(ftc.file_data);

					if ((ftc.chain_type == iControl.CommonFileChainType.FILE_LAST) ||
						 (ftc.chain_type == iControl.CommonFileChainType.FILE_FIRST_AND_LAST))
					{
						bContinue = false;
					}
				}
			}
			return file_contents;
		}

		public static bool uploadFile(iControl.Interfaces interfaces, string remote_file_path, string file_contents)
		{
			bool bUploaded = false;
			bool bContinue = true;
			long chunk_size = 64 * 1024;
			iControl.SystemConfigSyncFileTransferContext ftc = new iControl.SystemConfigSyncFileTransferContext();
			ftc.chain_type = iControl.CommonFileChainType.FILE_FIRST;
			long total_bytes = 0;
			System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
			string chunk = null;
            long chunk_length = 0;
            long file_length = file_contents.Length;

			if (interfaces.initialized)
			{
				while (bContinue)
				{
                    chunk_length = chunk_size;
                    if ( chunk_length > file_length-total_bytes )
                    {
                        chunk_length = file_length - total_bytes;
                    }
					chunk = file_contents.Substring((int)total_bytes, (int)chunk_length);
					if (chunk.Length != chunk_size)
					{
						if (0 == total_bytes)
						{
							ftc.chain_type = iControl.CommonFileChainType.FILE_FIRST_AND_LAST;
						}
						else
						{
							ftc.chain_type = iControl.CommonFileChainType.FILE_LAST;
						}
						bContinue = false;
					}
					ftc.file_data = encoding.GetBytes(chunk);
					total_bytes += chunk.Length;

					// Upload bytes
					interfaces.SystemConfigSync.upload_file(remote_file_path, ftc);
					ftc.chain_type = iControl.CommonFileChainType.FILE_MIDDLE;
				}
			}
			bUploaded = (total_bytes > 0);

			return bUploaded;
		}
	}
}
