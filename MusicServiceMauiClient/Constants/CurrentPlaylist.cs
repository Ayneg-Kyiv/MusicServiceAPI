using MusicServiceMauiClient.DTOs.MelodyDTOs;

namespace MusicServiceMauiClient.Constants
{
    public static class CurrentPlaylist
    {
        public static List<GetMelodyDTO>? MelodyList { get; set; }

        public static Guid? CurrentMelody {  get; set; }
        public static Guid? PrevMelody { get { return MelodyList?.TakeWhile(m => m.Id != CurrentMelody).DefaultIfEmpty(MelodyList?[^1]).LastOrDefault()?.Id; } }
        public static Guid? NextMelody { get { return MelodyList?.SkipWhile(m => m.Id != CurrentMelody).Skip(1).DefaultIfEmpty(MelodyList?[0]).FirstOrDefault()?.Id; } }

    }
}
