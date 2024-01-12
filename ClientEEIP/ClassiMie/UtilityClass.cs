using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientEEIP.ClassiMie
{
    public class UtilityClass
    {

        public static int Scrivi(ref byte[] arr, int index, object valore)
        {
            byte[] val = null;
            try
            {
                if (valore.GetType() == typeof(bool[]))
                {
                    val = BoolToByte((bool[])valore);
                }
                else if (valore.GetType() == typeof(byte[]))
                {
                    val = (byte[])valore;
                }
                else if (valore.GetType() == typeof(int[]))
                {
                    List<byte> tmp = new List<byte>();
                    int[] aus = (int[])valore;
                    for (int i = 0; i < aus.Length; i++)
                    {
                        tmp.AddRange(BitConverter.GetBytes(aus[i]));
                    }
                    val = tmp.ToArray();
                }
                else if (valore.GetType() == typeof(byte) || valore.GetType() == typeof(sbyte))
                {
                    val = new byte[] { (byte)valore };
                }
                else if (valore.GetType() == typeof(short))
                {
                    val = BitConverter.GetBytes((short)valore);
                }
                else if (valore.GetType() == typeof(ushort))
                {
                    val = BitConverter.GetBytes((ushort)valore);
                }
                else if (valore.GetType() == typeof(int))
                {
                    val = BitConverter.GetBytes((int)valore);
                }
                else if (valore.GetType() == typeof(uint))
                {
                    val = BitConverter.GetBytes((uint)valore);
                }
                else if (valore.GetType() == typeof(long))
                {
                    val = BitConverter.GetBytes((long)valore);
                }
                else if (valore.GetType() == typeof(ulong))
                {
                    val = BitConverter.GetBytes((ulong)valore);
                }
                else if (valore.GetType() == typeof(float))
                {
                    val = BitConverter.GetBytes((float)valore);
                }
                else if (valore.GetType() == typeof(string))
                {
                    val = Encoding.ASCII.GetBytes((string)valore);
                }
                else
                    throw new Exception("Type not supported");

                for (int i = 0; i < val.Length; i++)
                    arr[index + i] = val[i];
            }
            catch (Exception ex)
            {
                ClientEEIP.ExceptionHandler.HandleException(ex);
            }
            return val.Length;
        }

        private static byte[] BoolToByte(bool[] valori)
        {
            byte[] ret = new byte[1];
            try
            {
                for (byte i = 0; i < valori.Length; i++)
                    ret[0] |= (byte)((valori[i] ? 1 : 0) << i);
            }
            catch (Exception ex)
            {
                ClientEEIP.ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

        public static T Leggi<T>(byte[] arr, ref int index, int count = 0)
        {
            dynamic ret = default(T);
            try
            {
                if (typeof(T) == typeof(bool[]))
                {
                    ret = new bool[8];
                    for (int i = 0; i < 8; i++)
                        ret[i] = (arr[index] & 1 << i) > 0;
                    index++;
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    ret = arr.Skip(index).Take(count).ToArray();
                    index += count;
                }
                else if (typeof(T) == typeof(int[]))
                {
                    byte[] tmp = arr.Skip(index).Take(count * 4).ToArray();
                    ret = new int[count];
                    for (int i = 0; i < count; i++)
                    {
                        ret[i] = BitConverter.ToInt32(tmp, i * 4);
                    }
                    index += tmp.Length;
                }
                else if (typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
                {
                    ret = arr[index];
                    index++;
                }
                else if (typeof(T) == typeof(short))
                {
                    ret = BitConverter.ToInt16(arr, index);
                    index += 2;
                }
                else if (typeof(T) == typeof(ushort))
                {
                    ret = BitConverter.ToUInt16(arr, index);
                    index += 2;
                }
                else if (typeof(T) == typeof(int))
                {
                    ret = BitConverter.ToInt32(arr, index);
                    index += 4;
                }
                else if (typeof(T) == typeof(uint))
                {
                    ret = BitConverter.ToUInt32(arr, index);
                    index += 4;
                }
                else if (typeof(T) == typeof(long))
                {
                    ret = BitConverter.ToInt64(arr, index);
                    index += 8;
                }
                else if (typeof(T) == typeof(ulong))
                {
                    ret = BitConverter.ToUInt64(arr, index);
                    index += 8;
                }
                else if (typeof(T) == typeof(float))
                {
                    ret = BitConverter.ToSingle(arr, index);
                    index += 4;
                }
                else if (typeof(T) == typeof(string))
                {
                    ret = Encoding.UTF8.GetString(arr, index, count);
                    index += count;
                }
                //else if(typeof(T) == typeof(DateTime))    
                //{
                //    Console.WriteLine(typeof(DateTime));
                //    //ret = new DateTime(1980, 1, 1).AddMilliseconds(BitConverter.ToInt64(arr, index));
                //    ret = new DateTime(BitConverter.ToInt64(arr, index));
                //    index += 8;
                //}
                else
                    throw new Exception("Type not supported");
            }
            catch (Exception ex)
            {
                ClientEEIP.ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

    }
}