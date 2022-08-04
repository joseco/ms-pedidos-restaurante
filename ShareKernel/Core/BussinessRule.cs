namespace ShareKernel.Core
{
    public interface IBussinessRule
    {
        bool IsValid();

        string Message { get; }
    }
}
