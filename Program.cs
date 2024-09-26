using StringSerializer;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

F obj = F.Get();
string str = "";
DateTime before = DateTime.Now;
for(int i=0; i < 1000; i++)
{
    str = Serializator.Stringify(obj);
}
DateTime after = DateTime.Now;
Console.WriteLine($"сериализация в строку {str} за {after.Subtract(before).TotalMilliseconds} мс");

before = DateTime.Now;
for (int i = 0; i < 1000; i++)
{
    obj = Serializator.Destringify<F>(str);
}
after = DateTime.Now;
Console.WriteLine($"десериализация за {after.Subtract(before).TotalMilliseconds} мс");

before = DateTime.Now;
for (int i = 0; i < 1000; i++)
{
    str = JsonConvert.SerializeObject(obj);
}
after = DateTime.Now;
Console.WriteLine($"сериализация NewtonsoftJson за {after.Subtract(before).TotalMilliseconds} мс");

before = DateTime.Now;
for (int i = 0; i < 1000; i++)
{
    obj = JsonConvert.DeserializeObject<F>(str);
}
after = DateTime.Now;
Console.WriteLine($"десериализация NewtonsoftJson за {after.Subtract(before).TotalMilliseconds} мс");