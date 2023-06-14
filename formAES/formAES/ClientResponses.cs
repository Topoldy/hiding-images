using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace formAES
{
    class ClientResponses
    {
        private static UInt32 toUInt32(byte[] buff)
        {
            UInt32 number = 0;
            UInt32 tmp;

            tmp = buff[0];
            number = tmp << 24;

            tmp = buff[1];
            number ^= tmp << 16;

            tmp = buff[2];
            number ^= tmp << 8;

            tmp = buff[3];
            number ^= tmp;

            return number;
        }

        public static int CheckForConnection(NetworkStream stream)
        {
            byte[] buff = new byte[1];
            if(!stream.ReadAsync(buff,0,1).Wait(1000))
            {
                return -3;
            }

            return buff[0];
        }

        public static int SendItImagesResponse(NetworkStream stream)
        {
            byte[] buff = new byte[1];
            if (!stream.ReadAsync(buff, 0, 1).Wait(1000))
            {
                return -3;
            }

            return buff[0];
        }

        public static int SendItImagesRequest(NetworkStream stream, out UInt32 count, out UInt32 size, out string user_login)
        {
            count = 0;
            size = 0;
            user_login = "";
            try
            {
                byte[] buff_count = new byte[4];
                byte[] buff_size = new byte[4];

                if(!stream.ReadAsync(buff_count, 0, 4).Wait(1000))
                {
                    return -3;
                }
                if (!stream.ReadAsync(buff_size, 0, 4).Wait(1000))
                {
                    return -3;
                }

                count = toUInt32(buff_count);
                size = toUInt32(buff_size);

                int size_user_login = Convert.ToInt32(stream.ReadByte());
                byte[] buff_user_login = new byte[size_user_login];


                if (!stream.ReadAsync(buff_user_login, 0, size_user_login).Wait(1000))
                {
                    return -3;
                }

                user_login = Encoding.UTF8.GetString(buff_user_login);

                return 0;
            }
            catch
            {
                return -5;
            }
        }
    }
}
