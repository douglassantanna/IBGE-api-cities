namespace Cities
{
    public class City
    {
        public string id { get; set; }
        public string nome { get; private set; }

        public City(string nome)
        {
            this.nome = nome;
        }

        public void UpdateName(string name) => nome = name;

    }
}