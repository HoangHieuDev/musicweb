using Microsoft.CodeAnalysis.Scripting;
using music_app_model;
using NuGet.Packaging;
using System.Security.Cryptography;

namespace music_web_app.Data
{
    public class DbInitializer
    {
        public static void Initialize(music_web_app_DBContext context)
        {
            //Look for any students
            if (context.CategorySong.Any() ||
                context.History.Any() ||
                context.ListDetail.Any() ||
                context.PlayList.Any() ||
                context.Singer.Any() ||
                context.Song.Any() ||
                context.User.Any())
            {
                return; // DB has been seeded
            }

            var CategorySong = new CategorySong[]
            {
                new CategorySong{NameCategory="Nhạc buồn"},//Blues: nhạc buồn
                new CategorySong{NameCategory="Nhạc dân ca"},//Folk: nhạc dân ca
                new CategorySong{NameCategory="Nhạc Remix"},//Remix
                new CategorySong{NameCategory="Acoustic"},//Acoustic: Nhạc Acoustic, nói chung là loại nhạc được tạo ra bằng các nhạc cụ không phải điện tử
                new CategorySong{NameCategory="Dance"},//Dance: nhạc nhảy
                new CategorySong{NameCategory="Rock"},//Rock: nhạc rock
                new CategorySong{NameCategory="Hip hop"},//Hip hop: nhạc hip hop
                new CategorySong{NameCategory="Nhạc điện tử"},//Electronic: nhạc điện tử
                new CategorySong{NameCategory="Opera"},//Opera: nhạc opera
                new CategorySong{NameCategory="Nhạc giao hưởng"},//Symphony: nhạc giao hưởng
                new CategorySong{NameCategory="Nhac bolero"},//Reggae: nhạc reggae
            };
            context.CategorySong.AddRange(CategorySong);
            context.SaveChanges();

            var Singer = new Singer[]
{
                new Singer
                {
                    NameSinger = "Huy Vạc",
                    YearOfBirth = "11-11-1990",
                    Gender = "Male",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681217/Avatar/huyvac_ynblip.jpg"
                },
                new Singer
                {
                    NameSinger = "Nguyễn Đình Vũ",
                    YearOfBirth = "11-11-1990",
                    Gender = "Male",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681218/Avatar/nguyendinhvu_eovxpd.jpg"
                },
                new Singer
                {
                    NameSinger = "Gia Huy",
                    YearOfBirth = "11-11-1990",
                    Gender = "Male",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681217/Avatar/giahuy_sssfem.jpg"
                },
                new Singer
                {
                    NameSinger = "Khánh Ân",
                    YearOfBirth = "11-11-1990",
                    Gender = "Male", Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="http://res.cloudinary.com/dabdclkhv/image/upload/v1666663952/Image/JPEG_example_flower_kfjjtg.jpg"
                },
                new Singer
                {
                    NameSinger = "Khải Đăng",
                    YearOfBirth = "11-11-1990",
                    Gender = "Male", Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681504/Avatar/khaidangg_b2iqhe.jpg"
                },
                new Singer
                {
                    NameSinger = "Trịnh Đình Quang",
                    YearOfBirth = "11-11-1990",
                    Gender = "Male",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681614/Avatar/trinhdinhquang_cwfstd.jpg"
                },
                new Singer
                {
                    NameSinger = "Mỹ Tâm",
                    YearOfBirth = "11-11-1990",
                    Gender = "Female",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681617/Avatar/mytam_pkx1ie.jpg"
                },
                new Singer
                {
                    NameSinger = "Hồ Ngọc Hà",
                    YearOfBirth = "11-11-1990",
                    Gender = "Female",
                    Nationality ="Viet Nam", Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681615/Avatar/hongocha_jpyxgm.jpg"
                },
                new Singer
                {
                    NameSinger = "Hương Tràm",
                    YearOfBirth = "11-11-1990",
                    Gender = "Female",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681615/Avatar/huongtram_fh2nuj.jpg"
                },
                new Singer
                {
                    NameSinger = "Khởi My",
                    YearOfBirth = "11-11-1990",
                    Gender = "Female",
                    Nationality ="Viet Nam",
                    Biography="Mo ta",
                    AddDate = "Monday, October 24, 2022",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666681617/Avatar/khoimy_wwgcux.png"
                },
};
            context.Singer.AddRange(Singer);
            context.SaveChanges();

            var Song = new Song[]
            {
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666679881/Music/AnhThuongEmNhatMaAcousticCover-HuyVac-6009707_ybef8k.mp3",
                    NameSong = "Anh thương em nhất mà",
                    Lyric ="Ngược dòng thời gian quay về quá khứ\r\nAnh tìm lại những kí ức hôm nào\r\nLục tìm trong trí nhớ ngày đầu thu\r\nAnh mỉm cười nhớ bóng dáng của em\r\nNgày em đến bên anh là món quà\r\nAnh thầm ước nguyện từ bấy lâu\r\nNgày em đến bên anh là ánh dương\r\nMang tình yêu ngập tràn nơi anh\r\nAnh thương em nhất mà\r\nCớ sao bây giờ lại vội chia xa\r\nAnh yêu em nhất mà\r\nCớ sao bây giờ lại vội buông tay\r\nTừng day dứt ngày ấy vẫn luôn vẹn nguyên tình mình tựa mây bay\r\nLời theo gió nhẹ trôi tiếng yêu đầu môi lụi tàn nào ai hay\r\nCó người hỏi sao anh lại viết nhạc\r\nVì khó quên em nên không thể làm việc khác\r\nCớ sao anh luôn bên phím đàn\r\nVì nỗi nhớ em luôn tích tịch tình tang\r\nChuyện tình đẹp hay chuyện tình dở dang\r\nTình mình có thơ hay chỉ là lỡ làng\r\nTình mình giống như nàng Kiều và Kim Trọng\r\nBắt đầu thật đẹp để rồi toàn thở than\r\nAnh đã có cho mình những sai lầm\r\nChất thành đống nên giờ thật khó sửa\r\nTừ khi xa em nỗi nhớ tới làm bạn\r\nCòn đêm nay nỗi buồn đến gõ cửa.\r\nAnh tua ngược bộ phim của kí ức\r\nĐể một lần nữa sống trong kỉ niệm xưa\r\nTìm một ngày được bên nhau lần nữa\r\nSao khó như tìm hạt nắng trong vệt mưa.\r\nKhu vườn tình yêu không chăm sóc\r\nChỉ còn cành khô và vài nắm cỏ dại\r\nLàm sao để lau mi em khóc\r\nLàm sao để tình mình thắm trở lại?\r\nAnh không muốn cuộc sống mình vô vị\r\nNhư Tô Thị hóa đá chờ nghìn năm\r\nAnh chỉ muốn làm cao áp đô thị\r\nNơi em tối thì anh tới hỏi thăm.\r\nXa em rồi anh sẽ nhớ\r\nNhớ lần đầu đôi mình khẽ chạm môi\r\nNhớ cả cái nắm tay chiều hôm ấy\r\nNhớ cả những cái ôm mới đây thôi.\r\nAnh vẫn có cho mình những câu hỏi\r\nVề chuyện tình của hai ta\r\nRằng anh thương em nhất mà\r\nCớ sao bây giờ mình phải vội chia xa?",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 1,
                    IdSinger = 1,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666680102/Image/anhthuongemnhatma_z4zr1r.jpg",
                    Duration = 105
                },
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666680224/Music/KhatVongThuongLuu-NguyenDinhVu_3gz9w_lottwj.mp3",
                    NameSong = "Khác vọng thượng lưu",
                    Lyric ="Ai ai cũng có ước mơ giàu sang,để muốn thay đổi cuộc sống này.\r\nAi ai cũng muốn bước đi mình thành công, dù chưa một lần\r\nBao lần tôi bỏ qua suy nghĩ bước đến niềm tin mà tôi muốn đi\r\nĐi về nơi lý trí được bình yên .\r\n\r\nbonus:\r\nĐã sống là phải mơ, mặc kệ lời nói bên cạnh ta,\r\nDù ta nhắm mắt cố gắng bao điều khát vọng.\r\nHãy nhớ ta là ai và phải nhận biết cho ngày mai,\r\nĐừng để cuộc sống dối trá làm đánh mất.\r\nHãy luôn là chính mình, hãy luôn là chính mình,\r\nĐồng tiền dễ kiếm nhưng cũng dễ lầm người.\r\nĐổi thay lòng nhiều hơn, mất tất cả niềm vui,\r\nMột điều xin hãy nhớ mãi đừng đánh mất chính mình",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 2,
                    IdSinger = 2,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666680227/Image/khacvongthuongluu_mbaeua.jpg",
                    Duration = 205
                },
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666680531/Music/GiangHaiKhongDoNangDinhLongRemix-GiaHuySingerDinhLong-6916055_jsolnt.mp3",
                    NameSong = "Giang hải không độ nàng",
                    Lyric ="Phật từng nghe qua bài ca dao\r\nMà sao vẫn không độ nàng\r\nMột tiếng mõ không che đi vạn ý phàm\r\nLà bỉ ngạn hoa phủ tương tư\r\n\r\nĐường xưa loang lổ vết máu\r\nMộng này chết, đoạn một khúc tơ sầu\r\nTrùng phùng nơi Giang Hải thâm sâu\r\nNàng có muốn quay đầu không?\r\n\r\nNàng cố chấp như chưa tin vào ý Phật?\r\nThủy triều lên phi điểu bay cao\r\nTrần gian không còn ái ố\r\nNguyện một kiếp độ nàng thoát Tam Đồ\r\n\r\nHồng trần lâm ly vạn trang kinh\r\nChẳng mong sẽ không nhòa đi\r\nVà có lẽ trăm năm ta chẳng thấy nàng\r\nTừ ngày hoa khai, chờ mong ai\r\n\r\nBần tăng không còn gõ mõ\r\nĐường về tới chùa này vắng một người\r\nChỉ cười khi Giang Hải qua đi\r\nNàng có thấy yên bình không?\r\n\r\nLạc hoa hữu ý hay vô tình nước chảy?\r\nChờ ngày âm dương cùng thê lương\r\nPhật trên cao chẳng trông thấy\r\nĐể mình hắn độ nàng thoát luân hồi\r\n\r\nTrùng phùng nơi Giang Hải thâm sâu\r\nNàng có muốn quay đầu không?\r\nNàng cố chấp như chưa tin vào ý Phật?\r\nThủy triều lên phi điểu bay cao\r\n\r\nTrần gian không còn ái ố\r\nNguyện một kiếp độ nàng thoát Tam Đồ\r\nHồng trần lâm ly vạn trang kinh\r\nChẳng mong sẽ không nhòa đi\r\n\r\nVà có lẽ trăm năm ta chẳng thấy nàng\r\nTừ ngày hoa khai, chờ mong ai\r\nBần tăng không còn gõ mõ\r\nĐường về tới chùa này vắng một người\r\n\r\nChỉ cười khi Giang Hải qua đi\r\nNàng có thấy yên bình không?\r\nLạc hoa hữu ý hay vô tình nước chảy?\r\n\r\nChờ ngày âm dương cùng thê lương\r\nPhật trên cao chẳng trông thấy\r\nĐể mình hắn độ nàng thoát luân hồi",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 3,
                    IdSinger = 3,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666680533/Image/gianghaikhongdonang_un3fnj.jpg",
                    Duration = 191
                },
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666680674/Music/ThayLongDaiMeoRemix-NalTVkLeGiaQuan-7665869_aobjij.mp3",
                    NameSong = "Thay lòng",
                    Lyric ="Người đã từng thề hứa, ta sống đời có nhau\r\nCâu hứa chưa làm thế sao quên mau\r\nAi có ngờ đớn đau, đến khi yêu thật lòng\r\nNát lòng vỡ tan khi giấc mơ phai màu\r\n\r\nverse 2:\r\nThầm trách người lừa dối, che giấu tình đến sau\r\nEm bước theo người, có vui không em\r\nTrong tiết trời bão giông, đến vây quanh bầu trời\r\nNghìn trùng xa cách, biết em giờ ở nơi đâu\r\n\r\nchorus:\r\nTrái tim buồn đau, em giờ đây bước đi theo người\r\nBỏ quên dòng sông lá vẫn rơi nghe buồn xác xơ\r\nGió đông lại đây ôm lạnh giá chết giữa đất trời\r\nBóng chân ngả nghiêng, muôn lời than cung đàn ai oán\r\n\r\nTrái tim buồn đau, em giờ quên hết bao câu thề\r\nBão giông chẳng lo chi giờ em thay lòng đổi dạ\r\nNỡ quên ngày xưa ta cùng nhau sống chết có nhau\r\nDẫu muôn ngàn kiếp, chẳng trả hết nơi tình duyên ta",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 4,
                    IdSinger = 4,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666680672/Image/haylong_lztu4u.jpg",
                    Duration = 311
                },
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666680993/Music/HomNayEmCuoiRoiOrinnVinahouseRemix-KhaiDang-6882169_hq_trgz9s.mp3",
                    NameSong = "Ngày hôm nay em cưới rồi",
                    Lyric ="Muốn đi vài hôm xa chính nơi ta từng có phút êm đềm trước ngày giông tố đến tìm\r\nĐến khi nhận ra nên quý hơn những ngày tháng sống bên nhau thì mình muộn mất rồi\r\nGiờ nay em có lẽ rất vui cùng người em yêu chung bước không quay lại nhìn\r\nDù sao thì anh vẫn mong em luôn bình yên và xin lỗi vì chẳng đến chúc phúc cho em\r\n\r\nVì ngày hôm nay em cưới rồi vụn vỡ vết thương đau mãi trong tim\r\nNgười đàn ông may mắn ấy từ nay đã có em\r\nChỉ muốn đến đây gặp em một lần để thấy em hạnh phúc thế nào rồi anh đi\r\nVì ngày hôm nay em cưới rồi mai sau anh sống thế nào\r\n\r\nMột người đã mang cả thế giới sánh đôi với tình yêu mới\r\nNgày em đẹp nhất trên đời là ngày chúng ta xa một người\r\nNợ duyên đến nay mình trả hết rồi\r\nDù có một đời anh cố gắng thì vẫn không sao giữ em\r\n\r\nMột người đã mang cả thế giới sánh đôi với tình yêu mới\r\nNgày em đẹp nhất trên đời là ngày chúng ta xa một người\r\nNợ duyên đến nay mình trả hết rồi",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 5,
                    IdSinger =5,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666680992/Image/ngayhomnayemcuoiroi_xg0ia5.jpg",
                    Duration = 247
                },
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666701075/Music/TheGioiAoTinhYeuThat-TrinhDinhQuang-3875150_lklgx5.mp3",
                    NameSong = "Thế giới ảo tình yêu thật",
                    Lyric ="Có bao yêu thương anh này cũng trao cho em rồi\r\nDẫu biết em chưa bao giờ để ý\r\nCứ loay hoay theo từng cảm xúc mãi xoay vòng\r\nChẳng thể nào mà thoát ra dòng suy nghĩ\r\nNụ cười duyên dáng ánh mắt hiền hòa\r\nCứ mỗi khi cười là anh như chết lặng\r\nNgười ở một nơi, anh ở một trời\r\n\r\nTình yêu online nhưng anh sẽ thật thà nói với em\r\nAnh muốn bay xuyên thời gian xuyên không gian để tới bên em\r\nAnh muốn được đi cùng em trên đoạn đường đầy nắng\r\nHãy để cho anh được yêu em bằng tất cả những gì\r\nAnh đang có và sắp có và sẽ có\r\n\r\nChẳng cần biết em có làm sao thì anh vẫn mãi yêu em\r\nDẫu ở bên cạnh em bao nhiêu chàng trai hơn anh\r\nAnh chẳng sợ gì đâu vì anh to bằng cả thế giới này\r\nNơi đó chỉ giành riêng cho em\r\nAnh yêu em",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 6,
                    IdSinger =6,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684545/Image/thegioiaotinhyeuthat_sjoqlu.jpg",
                    Duration = 294
                },
                new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 2",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 3",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 4",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 5",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 6",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 7",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 8",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },new Song
                {
                    URL="https://res.cloudinary.com/dabdclkhv/video/upload/v1666684705/Image/ChoMong-MinhQuan_pwdp_jnb8pw.mp3",
                    NameSong = "Chờ mong 9",
                    Lyric ="Muôn tia nắng lung linh sớm mai\r\nXua tan hết âm u đêm dài\r\nSương khuya vẫn in trên lá xanh\r\nChờ em đến đây cùng anh.\r\n\r\nBao năm tháng héo khô bấy lâu\r\nMong anh đến xóa đi âu sầu\r\nCon tim khát khao thôi đớn đau\r\nTình yêu tái sinh trong nhau.\r\n\r\nNgười yêu hỡi\r\nEm vẫn trông theo cánh chim ngàn\r\nChờ anh đến, cùng bước đi trong vườn tình\r\nNgồi dưới hiên căn nhà xinh\r\nTừng ngày bên nhau đắm đuối\r\nSống trong tình yêu\r\nĐể lại sau lưng tháng năm\r\nĐếm cô đơn quạnh hiu\r\n\r\nHãy mau trở về\r\nCó tôi chờ người",
                    Listens = 0,
                    DateUpload = "Wednesday, October 26, 2022",
                    IdCategory = 7,
                    IdSinger = 7,
                    ImageSong = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666684709/Image/chomong_fc8p64.jpg",
                    Duration = 103
                },

            };
            context.Song.AddRange(Song);
            context.SaveChanges();


            var User = new User[]
            {
                new User
                {
                    UserName="Admin",
                    Name="Admin",
                    Pass=BCrypt.Net.BCrypt.HashPassword("admin"),
                    Email="Admin@gmail.com",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666685916/Image/img_325788_zeli7o.png",
                    IsAdmin=1,
                },
                new User
                {
                    UserName="User1",
                    Name="User1",
                    Pass=BCrypt.Net.BCrypt.HashPassword("User1"),
                    Email="User@gmail.com",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666686110/Image/21104_upibtd.png",
                    IsAdmin=0,
                },
                new User
                {
                    UserName="User2",
                    Name="User2",
                    Pass=BCrypt.Net.BCrypt.HashPassword("User2"),
                    Email="User@gmail.com",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666686110/Image/21104_upibtd.png",
                    IsAdmin=0,
                },
                new User
                {
                    UserName="User3",
                    Name="User3",
                    Pass=BCrypt.Net.BCrypt.HashPassword("User3"),
                    Email="User@gmail.com",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666686110/Image/21104_upibtd.png",
                    IsAdmin=0,
                },
                 new User
                {
                    UserName="User4",
                    Name="User4",
                    Pass=BCrypt.Net.BCrypt.HashPassword("User4"),
                    Email="User@gmail.com",
                    Avatar="https://res.cloudinary.com/dabdclkhv/image/upload/v1666686110/Image/21104_upibtd.png",
                    IsAdmin=0,
                },

            };
            context.User.AddRange(User);
            context.SaveChanges();

            var PlayList = new PlayList[]
{
                new PlayList{NameList="PlayList 1_1",IdUser = 1},
                new PlayList{NameList="PlayList 2_1",IdUser = 1},
                new PlayList{NameList="PlayList 3_1",IdUser = 1},
                new PlayList{NameList="PlayList 1_2",IdUser = 2},
                new PlayList{NameList="PlayList 2_2",IdUser = 2},
                new PlayList{NameList="PlayList 3_2",IdUser = 2},
                new PlayList{NameList="PlayList 1_3",IdUser = 3},
                new PlayList{NameList="PlayList 2_3",IdUser = 3},
                new PlayList{NameList="PlayList 3_3",IdUser = 3},
};
            context.PlayList.AddRange(PlayList);
            context.SaveChanges();

            var History = new History[]
            {
                new History{IdUser = 1, IdSong = 1},
                new History{IdUser = 1, IdSong = 2},
                new History{IdUser = 1, IdSong = 3},
                new History{IdUser = 1, IdSong = 4},
                new History{IdUser = 1, IdSong = 5},
            };
            context.History.AddRange(History);
            context.SaveChanges();


            var ListDetail = new ListDetail[]
            {
                new ListDetail{IdSong = 1, IdList = 1},
                new ListDetail{IdSong = 2, IdList = 2},
                new ListDetail{IdSong = 3, IdList = 3},
                new ListDetail{IdSong = 4, IdList = 4},
                new ListDetail{IdSong = 5, IdList = 5},
                new ListDetail{IdSong = 6, IdList = 6},
                new ListDetail{IdSong = 7, IdList = 7},
            };
            context.ListDetail.AddRange(ListDetail);
            context.SaveChanges();
        }
    }
}
