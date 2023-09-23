namespace Part1Api.Library
{
    public class Matematica
    {
        public static List<int> Decompor(int numero)
        {
            List<int> divisores = new();

            if (numero <= 0)
                return divisores;

            for (int i = 1; i <= (numero/2) + 1; i++)
            {
                if(numero % i == 0)
                    divisores.Add(i);
            }

            if(numero > 2)
                divisores.Add(numero);

            return divisores;
        }

        public static List<int> RemoverNumerosNaoPrimos(List<int> numeros)
        {
            numeros.RemoveAll(x => !NumeroPrimo(x));
            return numeros;
        }

        public static bool NumeroPrimo(int numero) 
        {
            if (numero <= 1)           
                return false;

            for (int i = 2; i < numero; i++)            
                if (numero % i == 0)                
                    return false;
                          
            return true;           
        }
    }
}