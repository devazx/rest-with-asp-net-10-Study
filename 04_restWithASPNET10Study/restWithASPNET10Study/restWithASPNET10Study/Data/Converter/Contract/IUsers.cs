namespace restWithASPNET10Study.Data.Converter.Contract
{
    public interface IUsers<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
