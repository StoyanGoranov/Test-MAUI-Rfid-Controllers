using System.Collections.Concurrent;
using Test.Entities;
using Test.Hardware;

namespace Test_RfidControllers;

public class Reader
{
    private VupVF747pController VF747PController;
    private ConcurrentQueue<string> _readData = new ConcurrentQueue<string>();
    public Reader()
    {
        VF747PController = new VupVF747pController("192.168.68.128", TimeSpan.FromMilliseconds(10));
    }

    public async Task StartReading(bool readFlag=true)
    {
        if (readFlag)
        {
            var data = await Task.Run(VF747PController.StartReading);
            foreach (var item in data)
            {
                _readData.Enqueue(item);
            }
        }
        else
        {
            VF747PController.StopReading();
        }

    }

    public IEnumerable<string> ProcessTags()
    {
        foreach (var tagData in _readData)
        {
            var number = int.Parse(tagData.Substring(0, 3));
            //process here?
            yield return $"Tag Number: {number} detected!";
        }
    }

    //public void ProcessTags()
    //{
    //    foreach (var tagData in _readData)
    //    {
    //        var number = int.Parse(tagData.Substring(0, 3));
    //        var timestamp = new Timestamp(DateTime.Now);
    //        var snapshot = new Snapshot(number, StaticOptions.GetRfidSnapshotType(), SnapshotMethod.RFID, timestamp);
    //        //process here?
    //    }
    //}
}
