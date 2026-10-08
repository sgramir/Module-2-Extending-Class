
using System;
using System.Reflection;

namespace MedicalDeviceCalibrationTracker
{
  //Interface for checking calibration status
  public interface ICalibratable
  {
    void CheckCalibration();
  }
  //Base class from Module 1
  public class MedicalDevice
  {
    //Five Properties
    public int DeviceID { get; set; }
    public string DeviceName { get; set; }
    public DateTime CalibrationDate { get; set; }
    public DateTime NextCalibrationDate { get; set; }
    public string Technician { get; set; }
    
    // Method 1: Display device information
    public void DisplayInfo()
    {
      Console.WriteLine("Device ID: " + DeviceID);
      Console.WriteLine("Device Name: " + DeviceName);
      Console.WriteLine("Calibration Date: " + CalibrationDate.ToShortDateString());
      Console.WriteLine("Nest Calibration Date: " + NextCalibrationDate.ToShortDateString());
      Console.WriteLine("Technician: " + Technician);
    }
  }
  //Derived class inherits MedicalDevice and implements ICalibratable
  public class DigitalCaliper : MedicalDevice, ICalibratable
  {
    public double MeasurementRange {get; set; }
    public double Accuracy { get; set; }
    
    //Method 2: Check calibration status
    public void CheckCalibration()
    {
      if (NextCalibrationDate < DateTime.Today)
      {
        Console.WriteLine("Calibration Status: Overdue");
      }
      else
      {
         Console.WriteLine("Calibration Status: Current");
      }
    }
    //Use reflection to print all properties
    public void printProperties()
    {
      PropertyInfo[] properties = GetType().GetProperties();

      foreach (PropertyInfo property in properties)
      {
        Console.WriteLine(property.Name + ": " + property.GetValue(this));
      }
    }
  }
  
  public class Program
  {
     public static void Main(string[] args)
    {
      DigitalCaliper device = new DigitalCaliper();

      device.DeviceID = 101;
      device.DeviceName = "Digital Caliper";
      device.CalibrationDate = new DateTime (2026, 8, 15);
      device.NextCalibrationDate = new DateTime (2027, 8, 15);
      device.Technician = "Lab Technician";
      device.MeasurementRange = 150.0;
      device.Accuracy = 0.02;

      Console.WriteLine("Medical Device Properties:");
      device.printProperties();

      Console.WriteLine();
       device.CheckCalibration();

    }
  }
}

    
    
