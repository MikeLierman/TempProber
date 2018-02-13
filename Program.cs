using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace TempProber
{
    class Program
    {
        static bool warn = false;
        static bool failed = false;
        static OpenHardwareMonitor.Hardware.Computer pcHW;
        static Dictionary<string, double> temps = new Dictionary<string, double>();


        static void Main(string[] args)
        {
            OnLoad();
        }

        private static void OnLoad()
        {
            /* CALL FUNCTION TO CHECK TEMPS. WE USE OPEN HARDDWARE MONITOR. */
            RefreshTemps();

            try
            {
                foreach (KeyValuePair<string, double> kvp in temps)
                {
                    if (kvp.Value > 190)
                    {
                        /* TEMPERATURE IS ABOVE 190F */
                        warn = true;
                    }

                    Console.WriteLine(kvp.Key + ": " + kvp.Value + "F, ");
                }
            }
            catch { failed = true; }

            if (temps.Count<1)
            {
                /* NOT ABLE TO CHECK TEMPERATURES. LIST EMPTY. 
                 * DO NOT FAIL CHECK, AS THAT WILL FAIL REPORTS DUE TO NO SENSORS. */
                Console.WriteLine(" FAILED. Unable to check temps."); Environment.Exit(0);
            }
            else if (warn) /* TEMPS ARE ABOVE THRESHOLD. */
            { Console.WriteLine(" FAILED. Temps above threshold."); Environment.Exit(-3);  }
            else { Console.WriteLine(" PASSED."); Environment.Exit(0); } /* OTHERWISE, SCRIPT CHECK PASSED. */

        }

        private static void RefreshTemps()
        {
            //- Variables
            warn = false;
            temps = new Dictionary<string, double>();

            //- Load Open Hardware Monitor library
            try
            {
                pcHW = new OpenHardwareMonitor.Hardware.Computer()
                {
                    CPUEnabled = true,
                    GPUEnabled = true,
                    HDDEnabled = true,
                };
                pcHW.Open();
            }
            catch { }

            try
            {
                for (int h = 0; h < pcHW.Hardware.Length; h++)
                {
                    var hw = pcHW.Hardware[h];
                    if (hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.CPU)
                    {
                        hw.Update();
                        Thread.Sleep(1000);
                        hw.Update();
                        Thread.Sleep(1000);
                        hw.Update();

                        for (int s = 0; s < hw.Sensors.Length; s++)
                        {
                            var sensor = hw.Sensors[s];
                            if (sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature)
                            {
                                if (sensor.Value != null)
                                {
                                    //- Get temperature value and convert that to F
                                    double val = (double)sensor.Value;
                                    val = Math.Round((val * 1.8) + 32, 0);

                                    temps.Add("CPU", val);
                                }
                            }
                        }
                    }
                    else if (hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.GpuAti ||
                             hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.GpuNvidia)
                    {
                        hw.Update();
                        for (int s = 0; s < hw.Sensors.Length; s++)
                        {
                            var sensor = hw.Sensors[s];
                            if (sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature)
                            {
                                if (sensor.Value != null)
                                {
                                    //- Get temperature value and convert that to F
                                    double val = (double)sensor.Value;
                                    val = Math.Round((val * 1.8) + 32, 0);

                                    temps.Add("GPU", val);
                                }
                            }
                        }
                    }
                    else if (hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.HDD)
                    {
                        hw.Update();

                        for (int s = 0; s < hw.Sensors.Length; s++)
                        {
                            var sensor = hw.Sensors[s];
                            if (sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature)
                            {
                                if (sensor.Value != null)
                                {
                                    //- Get temperature value and convert that to F
                                    double val = (double)sensor.Value;
                                    val = Math.Round((val * 1.8) + 32, 0);

                                    temps.Add("HDD", val);
                                }
                            }
                        }
                    }
                    else if (hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.Mainboard)
                    {
                        hw.Update();

                        for (int s = 0; s < hw.Sensors.Length; s++)
                        {
                            var sensor = hw.Sensors[s];
                            if (sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature)
                            {
                                if (sensor.Value != null)
                                {
                                    //- Get temperature value and convert that to F
                                    double val = (double)sensor.Value;
                                    val = Math.Round((val * 1.8) + 32, 0);

                                    temps.Add("Mobo", val);
                                }
                            }
                        }
                    }
                    else if (hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.RAM)
                    {
                        hw.Update();

                        for (int s = 0; s < hw.Sensors.Length; s++)
                        {
                            var sensor = hw.Sensors[s];
                            if (sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature)
                            {
                                if (sensor.Value != null)
                                {
                                    //- Get temperature value and convert that to F
                                    double val = (double)sensor.Value;
                                    val = Math.Round((val * 1.8) + 32, 0);

                                    temps.Add("RAM", val);
                                }
                            }
                        }
                    }
                    else if (hw.HardwareType == OpenHardwareMonitor.Hardware.HardwareType.Heatmaster)
                    {
                        hw.Update();

                        for (int s = 0; s < hw.Sensors.Length; s++)
                        {
                            var sensor = hw.Sensors[s];
                            if (sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature)
                            {
                                if (sensor.Value != null)
                                {
                                    //- Get temperature value and convert that to F
                                    double val = (double)sensor.Value;
                                    val = Math.Round((val * 1.8) + 32, 0);

                                    temps.Add("Heatsink", val);
                                }
                            }
                        }
                    }
                }
            }
            catch { failed = true; }
        }
    }
}
