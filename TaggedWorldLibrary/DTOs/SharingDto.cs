namespace TaggedWorldLibrary.DTOs
{
    /// <summary>
    /// Target oznacen sa TargetId se salje grupi (ReceiveGroupId) ili jednom korisniku (ReceiveUserId).
    /// </summary>
    public class SharingDto
    {
        public int TargetId { get; set; }

        public int? ReceiveGroupId { get; set; }

        public int? ReceiveUserId { get; set; }
    }
}
