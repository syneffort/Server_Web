using System;
using System.Threading.Tasks;

namespace AdvancedSyntax
{
    class Program
    {
        // Async는 다수의 스레드가 생기는 것을 의미하지 않음.
        // 단일 스레드가 다수의 일을 처리할 수 있도록 처리하는 것을 의미함.
        // 이를 통해 Threadsafe한 작업이 가능함.
        static Task Test()
        {
            Console.WriteLine("Start Test");
            Task t = Task.Delay(3000);
            return t;
        }

        // 작업 처리 중 다른 연산이 가능토록 비동기 처리
        static async Task<string> TestAsync()
        {
            Console.WriteLine("Start TestAsync");
            await Task.Delay(3000); // 복잡한 작업 ex. DB 또는 파일 작업 등..

            Console.WriteLine("End TesAsync");

            return "this is return";
        }

        static async Task Main(string[] args)
        {
            //Task t = Test();
            //t.Wait();

            Task<string> t = TestAsync();

            // 비동기 처리
            Console.WriteLine("while start");

            string ret = await t;
            Console.WriteLine(ret);

            while (true)
            {

            }
        }
    }
}
