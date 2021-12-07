using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;

namespace EssenceRealty.Domain.ViewModels
{
    public class ContactStaffViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool? AdminAccess { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public string Username { get; set; }
        public string Thumb_360PhotoURL { get; set; }
        public string OriginalPhotoURL { get; set; }
        public string About { get; set; }
        public string Specialities { get; set; }
        public string FacebookProfile { get; set; }
        public string InstagramProfile { get; set; }
        public string LinkedinProfile { get; set; }
        public ICollection<PhoneNumberViewModel> PhoneNumbers { get; set; }

        public string GetFullName()
        {
            return FirstName + LastName;
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:3.0");

            // Name        
            builder.Append("N:").Append(LastName)
              .Append(";").AppendLine(FirstName);

            // Full name        
            builder.Append("FN:").Append(FirstName)
              .Append(" ").AppendLine(LastName);

            // Other data        
            builder.Append("ORG:").AppendLine("Essence Realty");
            builder.Append("TITLE:").AppendLine(Role);
            builder.Append("TEL;TYPE=WORK:").AppendLine(PhoneNumbers.Where(x=>x.TypeCode == "W").Select(x=>x.Number).FirstOrDefault());
            builder.Append("TEL;TYPE=HOME:").AppendLine(PhoneNumbers.Where(x => x.TypeCode == "H").Select(x => x.Number).FirstOrDefault());
            builder.Append("TEL;TYPE=MOBILE:").AppendLine(PhoneNumbers.Where(x => x.TypeCode == "M").Select(x => x.Number).FirstOrDefault());
            builder.Append("URL:").AppendLine(WebsiteUrl);
            builder.Append("EMAIL;TYPE=EMAIL").AppendLine(Email);
            builder.Append("socialProfile;TYPE=FACEBOOK:").AppendLine(FacebookProfile);
            builder.Append("socialProfile;TYPE=TWITTER:").AppendLine();
            builder.Append("socialProfile;TYPE=LINKEDIN:").AppendLine(LinkedinProfile);
            builder.Append("socialProfile;TYPE=GPLUS:").AppendLine();
            builder.Append("socialProfile;TYPE=INSTAGRAM:").AppendLine(InstagramProfile);
            builder.Append("socialProfile;TYPE=YOUTUBE").AppendLine(Email);

            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(OriginalPhotoURL);
                builder.AppendLine("PHOTO;ENCODING=BASE64;TYPE=JPEG:");
                builder.AppendLine(Convert.ToBase64String(data));
                builder.AppendLine(string.Empty);
            }

            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }

    }
}
