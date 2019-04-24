namespace SliceFile.Contract
{
    public interface ISlice
    {
        //var videoPath = Console.ReadLine();
        //var destination = Console.ReadLine();
        //int pieces = int.Parse(Console.ReadLine());

        void Slice(string videoPath, string destinationPath, int pieces);
    }
}