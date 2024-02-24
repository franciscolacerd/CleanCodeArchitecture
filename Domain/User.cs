namespace Domain
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private User()
        { } // Construtor privado para o Entity Framework Core

        private User(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("O nome do usuário não pode ser nulo ou vazio.", nameof(name));
            }

            Name = name;
        }

        public static User Create(string name)
        {
            return new User(name);
        }
    }
}