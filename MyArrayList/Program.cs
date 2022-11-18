using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Concurrent;

namespace MyArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1,2,6,7,8,9,10};

            MyArrayList myArrayList = new MyArrayList(array);
            Console.WriteLine(myArrayList.ToString());
            int[] arr = new int[3] { 3,4,5 };
            myArrayList.AddListByIndex(arr, 2);

            
            
            

            

            

            //myArrayList.AddListToEnd(array);
            Console.WriteLine(myArrayList.ToString());
            //int count=myArrayList.DeleteAllElementsWithValue(4);
            //Console.WriteLine(myArrayList.ToString());
            //Console.WriteLine($"The number of deleted elements is: {count}");

            //int del_index = myArrayList.DeleteFirstElementWithValue(6);
            //Console.WriteLine(myArrayList.ToString());
            //Console.WriteLine($"The index of the deleted element is: {del_index}");

            //myArrayList.AddElementBegininng(1);
            //Console.WriteLine(myArrayList.ToString());
            //myArrayList.DeleteNFirstElements(2);
            //Console.WriteLine(myArrayList.ToString());


            /*
            myArrayList.DeleteLastElement();
            Console.WriteLine(myArrayList.ToString());
            myArrayList.DeleteFirstElement();
            Console.WriteLine(myArrayList.ToString());
            */
        }
    }
    public class MyArrayList
    {
        private int[] mylist;
        public MyArrayList()
        {
            mylist = null;
        }
        public MyArrayList(int element)
        {
            mylist = new int[1] { element };
        }
        public MyArrayList(int[] array)
        {
            mylist = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                mylist[i] = array[i];
            }
        }
        public string ToString()
        {
            string result = "";
            if (mylist != null)
            {
                for (int i = 0; i < mylist.Length; i++)
                {
                    if (i == 0)
                    {
                        result = mylist[i].ToString();
                    }
                    else
                    {
                        result = result + ", " + mylist[i].ToString();
                    }
                }
            }
            return result;
        }
        public int Length()
        {
            if (mylist == null)
            {
                return 0;
            }
            return mylist.Length;
        }
        public void AddElementEnd(int element)
        {
            if (mylist == null)
            {
                mylist = new int[1];
                mylist[0] = element;

            }
            else
            {
                Array.Resize(ref mylist, mylist.Length + 1);
                mylist[mylist.Length - 1] = element;
            }
        }
        public void AddElementBegininng(int element)
        {
            if (mylist == null)
            {
                mylist = new int[1];
                mylist[0] = element;
            }
            else
            {
                Array.Resize(ref mylist, mylist.Length + 1);
                int newlen = mylist.Length;
                for (int i = newlen - 1; i > 0; i--)
                {
                    mylist[i] = mylist[i - 1];
                }
                mylist[0] = element;
            }
        }
        public void AddElementByIndex(int index, int element)
        {
            if (mylist == null)
            {
                mylist = new int[index + 1];
                mylist[index] = element;
            }
            else if (index < mylist.Length)
            {
                Array.Resize(ref mylist, mylist.Length + 1);
                for (int i = mylist.Length - 1; i > index; i--)
                {
                    mylist[i] = mylist[i - 1];
                }
                mylist[index] = element;
            }
            else
            {
                Array.Resize(ref mylist, index + 1);
                mylist[index] = element;

            }
        }
        public void DeleteLastElement()
        {
            if (mylist == null)
            {
                Console.WriteLine("The arraylist is empty");

            }
            else
            {
                int[] temparray = new int[mylist.Length - 1];
                Array.Copy(mylist, 0, temparray, 0, mylist.Length - 1);
                mylist = temparray;
            }
        }
        public void DeleteFirstElement()
        {
            if (mylist == null)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                int[] temp = new int[mylist.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = mylist[i + 1];
                }
                mylist = temp;
            }
        }
        public void AddListToEnd(int[] array)
        {
            if (mylist == null)
            {
                mylist = new int[array.Length];
                for (int i = 0; i < mylist.Length; i++)
                {
                    mylist[i] = array[i];
                }
            }
            else
            {
                int first_length = mylist.Length;
                Array.Resize(ref mylist, mylist.Length + array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    mylist[first_length + i] = array[i];
                }
            }
        }
        public void AddListToBeginning(int[] array)
        {
            if(mylist == null)
            {
                mylist=new int[array.Length];
                for(int i=0;i<mylist.Length; i++)
                {
                    mylist[i] = array[i];
                }
            }
            else
            {
                int old_len=mylist.Length;
                Array.Resize(ref mylist, mylist.Length + array.Length);
                for(int i=0;i<old_len;i++)
                {
                    mylist[mylist.Length-1-i] = mylist[old_len-1-i];
                }
                for(int i = 0; i < array.Length; i++)
                {
                    mylist[i]=array[i];
                }
            }
            
        }
        public void AddListByIndex(int[] array,int index)
        {
            if (mylist == null)
            {
                mylist = new int[index +array.Length];
                for(int i = index; i < mylist.Length; i++)
                {
                    mylist[i] = array[i];
                }
            }
            else
            {
                int oldlen=mylist.Length;
                Array.Resize(ref mylist, mylist.Length + array.Length);
                int newlen=mylist.Length;
                int dif=newlen-oldlen;
                for(int i = oldlen - 1; i >= index; i--)
                {
                    mylist[i + dif] = mylist[i];
                }
                int j = 0;
                while (j < array.Length)
                {
                    mylist[index + j] = array[j];
                    j++;
                }
                
            }
        }
        public void DeleteElementByINdex(int index)
        {
            if (mylist == null)
            {
                Console.WriteLine("The list is empty :(");
            }
            else if (index >= mylist.Length)
            {
                Console.WriteLine("The index is out of the range :(");
            }
            else
            {
                int[] temp = new int[mylist.Length - 1];
                int j = 0;
                for (int i = 0; i < mylist.Length; i++)
                {
                    if (i == index)
                    {
                        continue;
                    }
                    temp[j] = mylist[i];
                    j++;
                }
                mylist = temp;
            }
        }
        public void DeleteNLastElements(int n)
        {
            if (mylist == null)
            {
                Console.WriteLine("The list is empty :(");
            }
            else if (n > mylist.Length)
            {
                Console.WriteLine("There are no n elements in the list :(");
            }
            else
            {
                int[] temp = new int[mylist.Length - n];
                for (int i = 0; i < mylist.Length - n; i++)
                {
                    temp[i] = mylist[i];
                }
                mylist = temp;

            }
        }
        public void DeleteNFirstElements(int n)
        {
            if (mylist == null)
            {
                Console.WriteLine("The list is empty :(");
            }
            else if (n > mylist.Length)
            {
                Console.WriteLine("There are no" + n + "elements in the list ");
            }
            else
            {
                int prev_len = mylist.Length;
                int[] temp = new int[mylist.Length - n];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = mylist[n + i];
                }
                mylist = temp;
            }
        }
        public int GetElementByIndex(int ind)
        {
            if (mylist == null)
            {
                Console.WriteLine("The list is empty");
                return -1;

            }
            else if (ind > mylist.Length - 1)
            {
                Console.WriteLine("This index does not exist in the list");
                return -1;
            }
            else
            {
                return mylist[ind];
            }
        }
        public int GetIndexByValue(int val)
        {

            if (mylist == null)
            {
                Console.WriteLine("The list is empty");
                return -1;
            }
            else
            {
                for (int i = 0; i < mylist.Length; i++)
                {
                    if (mylist[i] == val)
                    {

                        return i;
                    }

                }
                return -1;
            }
        }
        public int DeleteFirstElementWithValue(int value)
        {
            int index = -1;
            if (mylist != null)
            {
                int last_el = mylist[mylist.Length - 1];
                mylist[mylist.Length - 1] = value;
                int i = 0;
                while (mylist[i] != value)
                {
                    if (mylist[i] == value)
                    {
                        break;
                    }
                    i++;
                }
                if (i == mylist.Length - 1)
                {
                    if (last_el == value)
                    {
                        index = i;
                    }
                }
                else
                {
                    index = i;
                }
                mylist[mylist.Length - 1] = last_el;
                if (index >= 0)
                {
                    int[] temp = new int[mylist.Length - 1];
                    int k = 0;
                    for (int j = 0; j < mylist.Length; j++)
                    {
                        if (j == index)
                        {
                            continue;
                        }
                        temp[k] = mylist[j];
                        k++;
                    }
                    mylist = temp;

                }

            }
            return index;

        }
        public int DeleteAllElementsWithValue(int value)
        {
            int count = 0;
            if (mylist != null)
            {
                int[] temp = new int[mylist.Length ];
                int k = 0;
                for (int i = 0; i < mylist.Length; i++)
                {
                    if (mylist[i] != value)
                    {
                        temp[k] = mylist[i];
                        k++;
                    }
                }
                count = mylist.Length - k;
                Array.Resize(ref temp, k);
                mylist = temp;


            }
            return count;
        }
        public void DeleteNElementByIndecies(int index,int n)
        {
            if (mylist == null)
            {
                Console.WriteLine("The list is empty");
            }
            else if (index > mylist.Length - 1)
            {
                Console.WriteLine("The index is out of the list");
            }
            else
            {
                int size;
                size = mylist.Length - n;
                //Check if the index+n-1 exceeds the length of list ,if so size of new temp array is calculated different
                if (index+n-1 > mylist.Length-1)
                {
                    size = index;
                }
                int[] temp = new int[size];
                int k = 0;
                for (int i = 0; i < mylist.Length; i++)
                {
                    if (i == index)
                    {
                        i = index + n - 1;
                        continue;
                    }
                    temp[k] = mylist[i];
                    k++;
                }
                mylist = temp;
            }

        }
        public int Partition(int[] array,int l,int r)
        {
            int pivot = array[r];
            int k = l - 1;
            int temp;
            for(int i = l; i < r; i++)
            {
                if(array[i] <= pivot)
                {
                    k++;
                    temp = array[i];
                    array[i] = array[k];
                    array[k] = temp;
                    

                }
                temp = array[k + 1];
                array[k + 1] = array[r];
                array[r] = temp;
            }
            return k + 1;
        }
        public void SortByAscending(int l ,int r)
        {
            //quicksort algorithm
            if (l < r)
            {
                int p=Partition(mylist, l, r);
                SortByAscending(l,p-1);
                SortByAscending(p+1,r);
            }

        }



    }
}