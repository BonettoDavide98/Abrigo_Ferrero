using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QVLEGSCOG2362.DataType
{
    public class JpegCompression
    {

        private ImageCodecInfo jpgEncoder = null; //Encoder JPG utilizzato per salvare un'immagine JPEG settandogli la qualità desiderata.

        #region METODI_STATICI

        /// <summary>
        /// Salva una bitmap in formato Jpeg, nella qualità desiderata.
        /// </summary>
        /// <param name="bmp">Immagine da salvare</param>
        /// <param name="path">Percorso in cui salvare l'immagine, compreso il nome file</param>
        /// <param name="quality">Qualità, espressa in un valore da "0L" (minimo) a "100L" (massimo)</param>
        /// <returns>Ritorna true in caso di successo.</returns>
        public static bool SaveImage(Bitmap bmp, string path, long quality)
        {
            bool result = true;

            try
            {
                JpegCompression jpg = new JpegCompression();
                result = jpg.SaveImg(bmp, path, quality);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static byte[] SaveByteArray(Bitmap bmp, long quality)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    JpegCompression jpg = new JpegCompression();
                    Encoder myEncoder = Encoder.Quality;
                    bmp.Save(ms, jpg.jpgEncoder, jpg.getEncoderQuality(myEncoder, quality));
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public JpegCompression()
        {
            jpgEncoder = getEncoder(ImageFormat.Jpeg);
        }

        /// <summary>
        /// Salva una bitmap in formato Jpeg, nella qualità desiderata.
        /// </summary>
        /// <param name="bmp">Immagine da salvare</param>
        /// <param name="path">Percorso in cui salvare l'immagine, compreso il nome file</param>
        /// <param name="quality">Qualità, espressa in un valore da "0L" (minimo) a "100L" (massimo)</param>
        /// <returns>Ritorna true in caso di successo.</returns>
        public bool SaveImg(Bitmap bmp, string path, long quality)
        {
            bool result = true;

            try
            {
                using (Bitmap bmpTmp = new Bitmap(bmp))
                {
                    Encoder myEncoder = Encoder.Quality;

                    bmpTmp.Save(path, this.jpgEncoder, this.getEncoderQuality(myEncoder, quality));
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        private ImageCodecInfo getEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }

            return null;
        }

        /// <summary>
        /// Usato per ottenere una compressione variabile del JPEG
        /// </summary>
        /// <param name="encoder">Oggetto System.Drawing.Imaging.Encoder istanziato</param>
        /// <param name="quality">Qualità desiderata, in un range da 0L (minimo) a 100L (massimo)</param>
        /// <returns>Ritorna un oggetto EncoderParameters da utilizzare nel metodo Bitmap.Save(nomeFile, Encoder, EncoderParameters)</returns>
        private EncoderParameters getEncoderQuality(Encoder encoder, long quality)
        {
            EncoderParameters result = new EncoderParameters(1);
            EncoderParameter singleEncoder = new EncoderParameter(encoder, quality);

            result.Param[0] = singleEncoder;

            return result;
        }

    }
}