namespace restWithASPNET10Study.Data.Converter.Contract
{
    public interface IBook <O, D>
    {
        D parse(O origin);

        List<D> Parcelist(List<O> origin);
    }
}
