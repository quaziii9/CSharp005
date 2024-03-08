namespace CSharp005
{

    // Generic 
    

    internal class Program
    {

        #region 일반화 메서드

        public static void SwapValue<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static void ArrayCopy<T>(T[] source, T[] output)
        {
            for (int i = 0; i < source.Length; i++)
            {
                output[i] = source[i];
            }
        }

        #endregion

        #region 일반화 클래스
        // 클래스에 필요한 자료형을 일반화한다.
        // 클래스 인스턴스를 생성할때 자료형을 지정해서 사용

        class SafeArray<T>
        {
            private T[] array;

            // 배열의 크기를 인자로 받아서 초기화
            public SafeArray(int size)
            {
                array = new T[size];
            }

            public void Set(int index, T value)
            {
                if (index < 0 || index >= array.Length) return;

                array[index] = value;
            }
            public T Get(int index)
            {
                if (index < 0 || index>= array.Length)
                {
                    return default(T); // default : 자료형의 기본값 (T자료형의 기본값 0 리턴, 참조형은 NULL 리턴)
                }
                return array[index];
            }
        }
        #endregion

        class Item
        {
            private string Name;

            public Item(string name) 
            {
                Name = name;
            }
            public string GetName()
            {
                return Name;
            }
        }

        class Player
        {
            private SafeArray<Item> equippedItem;

            public Player(int size)
            {
                equippedItem = new SafeArray<Item>(size);
            }
            public void EquipItem(int num, Item item)
            {
                equippedItem.Set(num, item);
                Console.WriteLine($"장착된 {item.GetName()} 인덱스(칸){num}");
            }
            public Item GetEquippedItem(int num)
            {
                return equippedItem.Get(num);
            }
        }

        static void Main(string[] args)
        {
            #region 메서드
            //int x = 10;
            //int y = 20;
            ////SwapValue<int>(ref x, ref y);
            //SwapValue(ref x, ref y);
            //Console.WriteLine($"{x},{y}");
            ////매개변수를 통해서 추측이 가능하면 생략가능

            //double a = 1.1213;
            //double b = 2.6546;

            //SwapValue(ref a, ref b);
            //Console.WriteLine($"{a},{b}");

            //int[] iSrc = { 1, 2, 3, 4, 5, };
            //int[] iDst = new int[iSrc.Length];
            //ArrayCopy<int>(iSrc, iDst);
            //foreach (int i in iDst) 
            //{
            //    Console.WriteLine(i);
            //}
            //string[] sSrc = { "야호", "즐거운 금요일" };
            //string[] sDst = new string[sSrc.Length];
            //ArrayCopy(sSrc, sDst);
            //foreach (var item in sDst)
            //{
            //    Console.Write(item);
            //}
            //Console.WriteLine();
            #endregion

            #region 클래스
            //SafeArray<int> iArr = new SafeArray<int>(5);
            //iArr.Set(0, 10);
            //iArr.Set(6, 30);

            //Console.WriteLine("인덱스 0 : {0}" , iArr.Get(0));
            //Console.WriteLine("인덱스 6 : {0}", iArr.Get(6));  // 벗어나면 에러

            ///////////////////////////////////////////////////////////////////////////////

            Player player = new Player(5);

            Item sword = new Item("칼");
            Item shield = new Item("방패");
            Item potion = new Item("빨간포션");

            player.EquipItem(0, sword);
            player.EquipItem(2, shield);
            player.EquipItem(3, potion);

            for(int i =0; i < 5;i++)
            {

                Item equipItem = player.GetEquippedItem(i);

                if(equipItem != null)
                {
                    Console.WriteLine($"{i}칸 : {equipItem.GetName()}");
                }
                else
                {
                    Console.WriteLine($"{i}칸 : 없음" +
                        $"");
                }
            }
            #endregion


        }
    }
}
