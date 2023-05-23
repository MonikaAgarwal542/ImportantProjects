using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDS
{
    class HashNode<K, V>
    {
        public K key;
       public  V value;
       public  int hashcode;
       public  HashNode<K, V> next;
        public HashNode(K key, V value, int hashcode)
        {
            this.key = key;
            this.value = value;
            this.hashcode = hashcode;
        }
    }


    class HashTable<K, V>
    {
        ArrayList hashtable;
        int capacity;
        int size;
        public HashTable(int c)
        {
            hashtable = new ArrayList();
            capacity = c;
            size = 0;
            for (int i = 0; i < capacity; i++)
                hashtable.Add(null);
        }
        public int Size() { return size; }
        public bool isEmpty() { return Size() == 0; }

        public  int hashCode(K key)
        {
            return key.GetHashCode();
        }
        public int getBucketIndex(K key)
        {
            int hashcode = hashCode(key);
            int index = hashcode % capacity;
            index = index < 0 ? index * -1 : index;
            return index;
        }
        public V Contains(K key)
        {
            int index = getBucketIndex(key);
            int hashcode = hashCode(key);

            HashNode<K, V> head = (HashNode<K, V>)hashtable[index];

            while (head != null)
            {
                if (head.key.Equals(key) && head.hashcode == hashcode)
                    return head.value;
                head = head.next;
            }

            return default;

        }
        public V GetValueByKey(K key)
        {
           
            int index = getBucketIndex(key);
            int hashcode = hashCode(key);

            HashNode<K, V> head = (HashNode<K,V>)hashtable[index];

            while (head != null)
            {
                if (head.key.Equals(key) && head.hashcode == hashcode)
                    return head.value;
                head = head.next;
            }

            return default;
        }

        public void Insert(K key, V value)
        {
           
            int index = getBucketIndex(key);
            int hashcode = hashCode(key);
            HashNode<K, V> head = (HashNode<K, V>)hashtable[index];

            while (head != null)
            {
                if (head.key.Equals(key) && head.hashcode == hashcode)
                {
                    head.value = value;
                    
                    return;
                }
                head = head.next;
            }

            size++;
            head = (HashNode<K, V>)hashtable[index];
            HashNode<K, V> newNode
                = new HashNode<K, V>(key, value, hashcode);
            newNode.next = head;
            hashtable[index]=newNode;
            if (1.0 * size / capacity >= 0.7)
            {
                ArrayList temp = hashtable;
                hashtable = new ArrayList();
                capacity = 2 * capacity;
                size = 0;
                for (int i = 0; i < capacity; i++)
                    hashtable.Add(null);

                foreach(HashNode<K, V> headNode in temp)
                {
                    HashNode<K, V> node = headNode;
                    while (node != null)
                    {
                        Insert(node.key, node.value);
                        node = node.next;
                    }
                }
            }
           
        }
        public void Delete(K key)
        {
           
            int index = getBucketIndex(key);
            int hashcode = hashCode(key);
            
            HashNode<K, V> head = (HashNode<K, V>)hashtable[index];

            HashNode<K, V> prev = null;
            while (head != null)
            {
               
                if (head.key.Equals(key) && hashcode == head.hashcode)
                    break;

                prev = head;
                head = head.next;
            }

            if (head == null)
            {
                Console.WriteLine("Key not found");
                return;

            }
               

            size--;

            if (prev != null)
                prev.next = head.next;
            else
                hashtable[index] = head.next;

            Console.WriteLine("Key-Value pair deleted successfully.");
            Console.WriteLine();
        }
        public void Print()
        {
            Console.WriteLine("Key-Value pairs are : ");
            foreach (HashNode<K, V> headNode in hashtable)
            {
                HashNode<K, V> node = headNode;
                
                while (node != null)
                {
                    Console.WriteLine($"{node.key} : {node.value}");
                    node = node.next;
                }
            }
        }

    }
    class Program
    {
        static int capacity = -1;
        static HashTable<int, string> hashtable;
        static int flag = 1;
        static int key;
        static string value;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the capacity of the HashTable : ");
            if (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.WriteLine("NOTE : Enter the valid capacity.");
                return;

            }
            hashtable = new HashTable<int, string>(capacity);

            while (flag == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------***********************************---------------------------------------------");
                Console.WriteLine(" 1. Insert \n 2. Delete \n 3. Contains  \n 4. Get Value By Key \n 5. Size Of HashTable \n 6. Iterator \n 7. Print \n 8. Exit ");
                Console.Write("Enter your choice : ");
                int choice = -1;

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 11)
                {
                    Console.WriteLine("NOTE : Enter the correct choice.");

                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            if (hashtable.Size()==capacity)
                            {
                                Console.WriteLine("HashTable is full.");
                                break;
                            }
                            Console.Write("Enter the key to be inserted : ");
                            if (!int.TryParse(Console.ReadLine(), out key))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            Console.Write("Enter the value to be inserted : ");
                            value = Console.ReadLine();
                            hashtable.Insert(key, value);
                            Console.WriteLine("key-value pair inserted successfully.");
                            break;

                        case 2:
                            if (hashtable.isEmpty())
                            {
                                Console.WriteLine("HashTable is empty.");
                                break;
                            }
                            Console.Write("Enter the key to be deleted : ");
                            if (!int.TryParse(Console.ReadLine(), out key))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            hashtable.Delete(key);

                            break;
                        case 3:
                            if (hashtable.isEmpty())
                            {
                                Console.WriteLine("HashTable is empty.");
                                break;
                            }
                            Console.Write("Enter the key  : ");
                            if (!int.TryParse(Console.ReadLine(), out key))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            try
                            {
                                if (hashtable.GetValueByKey(key).Equals(" ")) Console.WriteLine("");
                                else Console.WriteLine($"Key Found and the key-value pair is {key} : {hashtable.Contains(key)} ");
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine("Key not found.");
                            }

                            break;
                        case 4:
                            if (hashtable.isEmpty())
                            {
                                Console.WriteLine("HashTable is empty.");
                                break;
                            }
                            Console.Write("Enter the key  : ");
                            if (!int.TryParse(Console.ReadLine(), out key))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            try
                            {
                                if (hashtable.GetValueByKey(key).Equals(" ")) Console.WriteLine("Key not found");
                                else Console.WriteLine($"value for the {key} is :{hashtable.GetValueByKey(key)} ");
                            }
                            catch(NullReferenceException e)
                            {
                                Console.WriteLine("Key not found.");
                            }
                            break;
                        case 5:
                            if (hashtable.isEmpty())
                            {
                                Console.WriteLine("HashTable is empty.");
                                break;
                            }
                            Console.WriteLine($"Size of the priority Queue is : {hashtable.Size()}");
                            break;
                        case 6:
                            if (hashtable.isEmpty())
                            {
                                Console.WriteLine("HashTable is empty.");
                                break;
                            }
                            hashtable.Print();
                            break;
                        case 7:
                            if (hashtable.isEmpty())
                            {
                                Console.WriteLine("HashTable is empty.");
                                break;
                            }
                            hashtable.Print();
                            break;
                       
                        default:
                            flag = -1;
                            break;

                    }

                }

            }


        }
    }
}



