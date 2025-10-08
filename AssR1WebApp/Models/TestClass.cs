namespace AssR1WebApp.Models
{
    public class TestClass
    {
        
        public void Add(int no1,int no2)
        {
            Student std = new Student();
            object obj3 = std;//boxing
            dynamic x = 10;

            var xxxx = x;

            Student std2 = obj3 as Student;




            dynamic y = "Mohamed";
            dynamic obj = new Student();
            obj.Id = "10";
            obj = x + y;
            dynamic obj2 = new Object();

            //
        }

        public void PrintAdd()
        {
            int a = 10;
            int b = 20;
            Add(a, b);
            int x = 10;
            int y = 20;
            Add(x, y);
        }
    }

  
}
