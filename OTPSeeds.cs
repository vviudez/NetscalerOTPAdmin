using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace NetscalerOTPAdmin
{
    class OTPSeeds
    {

        internal static string GenerateSeedString(string device,string seed) {

            string updatedattribute = "";
            if ((String.IsNullOrEmpty(device)) || (String.IsNullOrEmpty(seed)))
            {
                throw new Exception("Device name or Seed value are not valid!");
            }
            
            updatedattribute += device + "=" + seed + "&,";

            if (!String.IsNullOrEmpty(updatedattribute))
            {
                updatedattribute = "#@" + updatedattribute;
            }

            return updatedattribute;
        }

        internal static string AddNewSeed(string allseeds,string device, string seed)
        {

            string updatedattribute = "";
            if ((String.IsNullOrEmpty(device)) || (String.IsNullOrEmpty(seed)))
            {
                throw new Exception("Device name or Seed value are not valid!");
            }

            updatedattribute += device + "=" + seed + "&,";

            if (!String.IsNullOrEmpty(allseeds))
            {
                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    allseeds += updatedattribute;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    allseeds = "#@" + updatedattribute;
                }
            }

            return allseeds;
        }



        internal static string RegenerateSeedString(ListViewItemCollection items)
        {
            string updatedattribute = "";
            if (items != null)
            {
                foreach (ListViewItem li in items)
                {
                    string device = li.SubItems[0].Text;
                    string seed = li.SubItems[1].Text;
                    updatedattribute += device + "=" + seed + "&,";
                }

                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    updatedattribute = "#@" + updatedattribute;
                }
            }
            else
            {
                throw new Exception("List Itemss Collection are not valid!");
            }
            return updatedattribute;
        }

        internal static string RegenerateSeedString(string[] items)
        {
            string updatedattribute = "";
            if (items != null)
            {
                foreach (string seedt in items)
                {
                    string[] seedarr = seedt.Split('=');
                    updatedattribute += seedarr[0] + "=" + seedarr[1] + ",";
                }

                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    updatedattribute = "#@" + updatedattribute;
                }
            }
            else
            {
                throw new Exception("Items array are not valid!");
            }
            return updatedattribute;
        }



        internal static string RenameDevice(string seeds, string oldname, string newname)
        {

            if ((String.IsNullOrEmpty(seeds)) || (String.IsNullOrEmpty(oldname)) || (String.IsNullOrEmpty(newname)))
            {
                throw new Exception("Incorrect parameters o null parameters!");
            }

            seeds = seeds.Substring(2);
            // Remove the last , of the seed string
            seeds = seeds.Remove(seeds.Length - 1);

            // split all the seeds 
            string[] arr_seeds = seeds.Split(',');

            string updatedattribute = "";
            // and search all the seeds for the device to modify
            foreach (string seedt in arr_seeds)
            {
                string[] seedarr = seedt.Split('=');
                // If the device name of the seed corresponds with the original device name, we change this name using the input of the user
                if (oldname == seedarr[0])
                {
                    seedarr[0] = newname;
                }
                updatedattribute += seedarr[0] + "=" + seedarr[1] + ",";
            }

            if (String.IsNullOrEmpty(updatedattribute))
            {
                updatedattribute = "#@" + updatedattribute;
            }

            return updatedattribute;
        }

    }
}
