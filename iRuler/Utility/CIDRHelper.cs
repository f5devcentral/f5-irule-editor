//===========================================================================
//
// File         : CIDRHelper.cs
//                   
//---------------------------------------------------------------------------
//
// The contents of this file are subject to the "END USER LICENSE AGREEMENT FOR F5
// Software Development Kit for iControl"; you may not use this file except in
// compliance with the License. The License is included in the iControl
// Software Development Kit.
//
// Software distributed under the License is distributed on an "AS IS"
// basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
// the License for the specific language governing rights and limitations
// under the License.
//
// The Original Code is iControl Code and related documentation
// distributed by F5.
//
// The Initial Developer of the Original Code is F5 Networks, Inc.
// Seattle, WA, USA.
// Portions created by F5 are Copyright (C) 2006 F5 Networks, Inc.
// All Rights Reserved.
// iControl (TM) is a registered trademark of F5 Networks, Inc.
//
// Alternatively, the contents of this file may be used under the terms
// of the GNU General Public License (the "GPL"), in which case the
// provisions of GPL are applicable instead of those above.  If you wish
// to allow use of your version of this file only under the terms of the
// GPL and not to allow others to use your version of this file under the
// License, indicate your decision by deleting the provisions above and
// replace them with the notice and other provisions required by the GPL.
// If you do not delete the provisions above, a recipient may use your
// version of this file under either the License or the GPL.
//
//===========================================================================
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace iRuler.Utility
{
    static class CIDRHelper
    {
        private static String[] m_lookupTable = {
            "",
            "128.0.0.0",
            "192.0.0.0",
            "224.0.0.0",
            "240.0.0.0",
            "248.0.0.0",
            "252.0.0.0",
            "254.0.0.0",
            "255.0.0.0",
            "255.128.0.0",
            "255.192.0.0",
            "255.224.0.0",
            "255.240.0.0",
            "255.248.0.0",
            "255.252.0.0",
            "255.254.0.0",
            "255.255.0.0",
            "255.255.128.0",
            "255.255.192.0",
            "255.255.224.0",
            "255.255.240.0",
            "255.255.248.0",
            "255.255.252.0",
            "255.255.254.0",
            "255.255.255.0",
            "255.255.255.128",
            "255.255.255.192",
            "255.255.255.224",
            "255.255.255.240",
            "255.255.255.248",
            "255.255.255.252",
            "255.255.255.254",
            "255.255.255.255",
        };

        public static String getMask(int shorthand)
        {
            String sMask = null;
            if ((shorthand >= 1) && (shorthand <= 32))
            {
                sMask = m_lookupTable[shorthand];
            }
            return sMask;
        }

        public static long getShorthand(String mask)
        {
            long shorthand = -1;

            for (int i = 1; i < m_lookupTable.Length; i++)
            {
                if (mask.Equals(m_lookupTable[i]))
                {
                    shorthand = i;
                    break;
                }
            }

            return shorthand;
        }

        public static bool isValidNetworkAddress(String address, String mask)
        {
            // address == address & mask;
            bool bValid = false;
            try
            {
                System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(address);
                if (ipaddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    // IPV6 has it's own rules and since the CIDR is just a "prefix length" consisting of left-aligned
                    // contiguous bits.
                    bValid = true;
                }
                else
                {
                    // TODO: This won't work for IPv6!
                    System.Net.IPAddress ipmask = System.Net.IPAddress.Parse(mask);
                    //if (ipaddr.Address == (ipaddr.Address & ipmask.Address))
                    if (IPAddress.Equals(ipaddr.Address, (ipaddr.Address & ipmask.Address)))
                    {
                        bValid = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return bValid;
        }

        public static bool isValidNetworkAddress(String address, int shorthand)
        {
            bool bValid = false;
            String mask = getMask(shorthand);
            if (null != mask)
            {
                bValid = isValidNetworkAddress(address, mask);
            }
            return bValid;
        }
    }
}
