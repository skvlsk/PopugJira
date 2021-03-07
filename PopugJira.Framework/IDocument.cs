namespace PopugJira.Framework
{
    public interface IDocument
    {
        
    }

    public interface IDocument<TKey> : IDocument
    {
        public TKey Id { get; set; }
        public AuditInfo AuditInfo { get; set; }
    }
}