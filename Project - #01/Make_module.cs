class Human
    {
        public string name;         
        public byte Age;
        // Устанавливаем параметры 
        public Human(string n, byte a)
        {
            name = n;
            Age = a;
        }
        public ~Human()
        {
               Console.WriteLine("Object was destroyed");
        }
        public void getInfo()
        {
          Console.WriteLine("Name: {0}\nAge: {1}", name, Age);
        }
    }
