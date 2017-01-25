/*
 The MIT License (MIT)
 Copyright(c) 2016 Haruki Tachihara
*/
using UnityEngine;
using UnityEditor;

namespace Niki
{
    /// <summary>
    /// ニキニキのアイテムデータ
    /// </summary>
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
    }
}

