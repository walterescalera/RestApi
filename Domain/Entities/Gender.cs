public enum Gender
{
    MASCULINO,
    FEMENINO,
    NOBINARIO
}

public static class GenderHelper
{
    public static Gender Parse(string genero)
    {
        switch (genero.ToUpper())
        {
            case "M":
                return Gender.MASCULINO;
            case "F":
                return Gender.FEMENINO;
            case "X":
                return Gender.NOBINARIO;
            default:
                throw new ArgumentException("El género proporcionado no es válido.");
        }
    }
}
