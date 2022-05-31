namespace WebApplication3
{
    public class Dal2
    {
        // Singleton
        private static Dal2 dal2;

        public Dal2()
        {
            Foo();
        }

        public static Dal2 GetInstance()
        {
            if (dal2 == null) dal2 = new Dal2();
            return dal2;
        }

        public string Foo()
        {
            string str = "I HAVE RETURNED!" +
                "/n" +
                "/n" +
                "(by Foo of dal 2)";

            return str;
        }
    }
}
