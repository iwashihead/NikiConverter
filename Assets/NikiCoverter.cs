/*
 The MIT License (MIT)
 Copyright(c) 2016 Haruki Tachihara
*/
using UnityEngine;
using UnityEditor;
using System;

namespace Niki
{
    /// <summary>
    /// ニキニキのアイテムデータ
    /// </summary>
	[Serializable]
    public class NikiItem
    {
        /// <summary>
        /// コーデ部位
        /// </summary>
        public enum PartsType
        {
            /// <summary>髪型</summary>
            Hair,
            /// <summary>ドレス</summary>
            Dress,
            /// <summary>コート</summary>
            Coat,
            /// <summary>トップス</summary>
            Tops,
            /// <summary>ボトムス</summary>
            Bottoms,
            /// <summary>靴下</summary>
            Socks,
            /// <summary>サブソックス（ガーターとか）</summary>
            SubSocks,
            /// <summary>シューズ</summary>
            Shoes,
            /// <summary>ヘアアクセサリー</summary>
            HairAccessory,
            /// <summary>耳飾り</summary>
            Ear,
            /// <summary>首飾り</summary>
            Neck,
            /// <summary>腕飾り 左</summary>
            HandL,
            /// <summary>腕飾り 右</summary>
            HandR,
            /// <summary>腕飾り 手袋</summary>
            Glove,
            /// <summary>手持ち品 左</summary>
            ItemL,
            /// <summary>手持ち品 右</summary>
            ItemR,
            /// <summary>腰飾り</summary>
            Waist,
            /// <summary>特殊</summary>
            Special,
            /// <summary>メイク</summary>
            Makeup,
        }

        public PartsType Type;
        public Texture TitleTexture;
        public Texture SumnailTexture;
        public CodeStatus Status;
    }

    /// <summary>
    /// コーデステータス
    /// </summary>
	[Serializable]
    public struct CodeStatus
    {
        /// <summary>
        /// コーデステータス1
        /// </summary>
        public enum CodeStatus1
        {
            /// <summary>シンプル</summary>
            Simple,
            /// <summary>華麗</summary>
            Magnificent
        }

        /// <summary>
        /// コーデステータス2
        /// </summary>
        public enum CodeStatus2
        {
            /// <summary>エレガント</summary>
            Elegant,
            /// <summary>アクティブ</summary>
            Active,
        }

        /// <summary>
        /// コーデステータス3
        /// </summary>
        public enum CodeStatus3
        {
            /// <summary>大人</summary>
            Adult,
            /// <summary>キュート</summary>
            Cute,
        }

        /// <summary>
        /// コーデステータス4
        /// </summary>
        public enum CodeStatus4
        {
            /// <summary>セクシー</summary>
            Sexy,
            /// <summary>キュート</summary>
            Pure,
        }

        /// <summary>
        /// コーデステータス5
        /// </summary>
        public enum CodeStatus5
        {
            /// <summary>ウォーム</summary>
            Warm,
            /// <summary>クール</summary>
            Cool,
        }

        public CodeStatus1 st1;
        public CodeStatus2 st2;
        public CodeStatus3 st3;
        public CodeStatus4 st4;
        public CodeStatus5 st5;
    }
}

namespace Niki.Converter
{
    /// <summary>
    /// ミラクルニキのSSをデータに変換します
    /// </summary>
    public class NikiCoverter : EditorWindow
    {
        [MenuItem("NikiConverter")]
        public static void Open()
        {
            GetWindow<NikiCoverter>();
        }

        public void OnGUI()
        {
            // TODO GUI表示
        }

        /// <summary>
        /// 一括返還処理
        /// </summary>
        public static void CovertAll()
        {

        }

		/// <summary>
		/// ニキニキのSS画像からアイテムデータへ変換
		/// </summary>
		/// <returns>The to item.</returns>
		/// <param name="tex">Tex.</param>
		public NikiItem ConvertToItem(Texture2D tex)
		{
			
		}
    }

	/// <summary>
	/// テクスチャ比較に関するライブラリ
	/// </summary>
	public static class TextureMatching
	{
		/// <summary>
		/// 2枚のTextureを比較し、ピクセルの一致率を計算して返します
		/// </summary>
		/// <param name="t1">1枚目の比較するテクスチャ.</param>
		/// <param name="t2">2枚目の比較するテクスチャ.</param>
		/// <param name="admitableRange">許容する誤差 0..1 0で完全一致</param>
		public float GetMatchingRate(Texture2D t1, Texture2D t2, float admitableRange = 0f)
		{
			if (t1 == null || t2 == null)
			{
				Debug.LogError ("Matching Target Texture not found!. tex1 : " + (t1 != null) + " tex2 : " + (t2 != null));
				return 0f;
			}

			Texture2D targetTex = t2;
			if (t1.width != t2.width || t1.height != t2.height)
			{
				// 比較対象のテクスチャサイズが比較元のテクスチャサイズと異なる場合
				// 新しく同サイズのテクスチャを生成する
				var t2n = new Texture2D (t2.width, t2.height);
				t2n.SetPixels (t2.GetPixels ());
				t2n.Resize (t1.width, t1.height);
				targetTex = t2n;
			}

			int equalCnt = 0;
			for (int x = 0; x < t1.width; x++)
			{
				for (int y = 0; y < t1.height; y++)
				{
					var c1 = t1.GetPixel (x, y);
					var c2 = targetTex.GetPixel (x, y);
					if (c1 == c2) equalCnt++;
				}
			}

			// 有効一致ピクセル数
			var availablePixcelCnt = Mathf.RoundToInt (t1.width * t2.width * (1f - admitableRange));
			return equalCnt >= availablePixcelCnt;
		}



	}

	public static class MathExtension
	{
		/// <summary>
		/// 安全な浮動小数点の同値比較
		/// </summary>
		/// <returns><c>true</c>値は等しい, <c>false</c> それ以外.</returns>
		/// <param name="f1">値1.</param>
		/// <param name="f2">値2.</param>
		/// <param name="threshold">誤差.</param>
		public bool SafeEquals(float f1, float f2, float threshold = 0.000001f)
		{
			return Mathf.Abs (f1 - f2) <= threshold;
		}

		/// <summary>
		/// 安全な浮動小数点の同値比較
		/// </summary>
		/// <returns><c>true</c>値は等しい, <c>false</c> それ以外.</returns>
		/// <param name="d1">値1.</param>
		/// <param name="d2">値2.</param>
		/// <param name="threshold">誤差.</param>
		public bool SafeEquals(double d1, double d2, double threshold = 0.0000000001)
		{
			return Mathf.Abs (d1 - d2) <= threshold;
		}
	}
}