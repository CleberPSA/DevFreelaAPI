namespace DevFreela.API.Services
{
    public interface IConfigService
    {
        int GetValues();
    }


    public class ConfigService : IConfigService
    {

        private int _value;

        public int GetValues()
        {
            _value++;

            return _value;
        }
    }
}
