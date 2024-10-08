using Test.Entities;
using Test.Hardware;

namespace Test_RfidControllers
{
    public class Writer
    {
        private VupVD67Controller VD67Controller;

        public Writer()
        {
            VD67Controller = new VupVD67Controller(TimeSpan.FromMilliseconds(100));
        }

        public async Task<Tag> Write(int number)
        {
            var data = await Task.Run(VD67Controller.Read);
            var id = data.Substring(9);
            var tag = new Tag(id, number);
            VD67Controller.Write(tag.PrepareToWrite());
            return tag;
        }
    }

}
