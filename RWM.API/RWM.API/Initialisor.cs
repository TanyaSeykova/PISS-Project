using RWM.Services.Contracts;

namespace RWM.API
{
    public class Initialisor : IInitialisor
    {
        private readonly IBookJsonReader _bookReader;

        public Initialisor(IBookJsonReader bookReader)
        {
            _bookReader = bookReader;
        }

        public void Initialise()
        {
            _bookReader.ReadJsonFile();
        }
    }
}
