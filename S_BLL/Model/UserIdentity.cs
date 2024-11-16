using System.Diagnostics.CodeAnalysis;

namespace S_BLL.Model
{
    public struct UserIdentity
    {
        private readonly Memory<byte> _id;

        public UserIdentity(byte[] identity)
        {
            _id = new Memory<byte>(identity);
        }

        public UserIdentity(Memory<byte> identity)
            : this(identity.ToArray())
        { }

        public UserIdentity(string byteStr)
        {
            ArgumentException.ThrowIfNullOrEmpty(byteStr, nameof(byteStr));

            try
            {
                _id = new Memory<byte>(byteStr.Split(' ').Select(s => Byte.Parse(s)).ToArray());
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Невозможно преобразовать " +
                    "данную строку байтов в идентификатор пользователя");
            }
        }

        public static bool operator ==(UserIdentity left, UserIdentity right) 
        { 
            return left._id.Equals(right._id);
        }

        public static bool operator !=(UserIdentity left, UserIdentity right) 
        { 
            return !left._id.Equals(right._id);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj, nameof(obj));

            return _id.Equals((Memory<byte>)obj);
        }

        public byte[] ToByteArray()
        {
            return _id.ToArray();
        }

        public override string ToString()
        {
            return String.Join(" ", _id.ToArray());
        }
    }
}
