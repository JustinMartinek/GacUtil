using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacUtil
{
    public class GacUtil
    {
        public static void Main(string[] args)
        {
            if (args.Length.Equals(0)||args[args.Length - 1] == "-h" )
            {
                Console.WriteLine("Beginning Help:");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("*REMEMBER TO RUN WITH ELEVATED PERMISSIONS!*");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Use the following flags to gac an assembly");
                Console.WriteLine("==Parameter 1==");
                Console.WriteLine("-i:      Installs the assembly");
                Console.WriteLine("-u:      Uninstalls the assembly");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("==Parameter 2==");
                Console.WriteLine("Full path to the assembly");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("==Parameter 3==");
                Console.WriteLine("-f:      flag to force the installation");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("EX: ");
                Console.WriteLine("GacUtil.exe -i C:/Folder/installable.dll -f");

            }
            else if (args[0] == "-i")
            {
                Console.WriteLine("Installing Assembly");
                if (args.Count() < 2)
                {
                    Console.WriteLine("Not enough parameters supplied.  Please consult the help functionality.");
                }
                else
                {
                    bool flag = false;
                    if (args.Count() > 2 && args[2] == "-f")
                        flag = true;
                    if (flag)
                        Console.WriteLine("Flag used to force assembly installation");
                    try
                    {
                        GacUtilHelper.InstallAssembly(args[1], flag);
                        Console.WriteLine("Installation Complete");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Installation failed: {ex.ToString()}");
                    }
                }
            }
            else if (args[0] == "-u")
            {
                Console.WriteLine("Uninstalling Assembly");
                if (args.Count() < 2)
                {
                    Console.WriteLine("Not enough parameters supplied.  Please consult the help functionality.");
                }
                else
                {
                    try
                    {
                        GacUtilHelper.UninstallAssembly(args[1]);
                        Console.WriteLine("Uninstall Complete");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Uninstallation failed: {ex.ToString()}");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("flag undefined.  Use -h for help");
            }
        }
    }

}
