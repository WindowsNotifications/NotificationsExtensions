// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Text;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions.Tiles
{
    internal enum TileTemplateNameV1
    {
        TileSquareBlock,
        TileSquareImage,
        TileSquarePeekImageAndText01,
        TileSquarePeekImageAndText02,
        TileSquarePeekImageAndText03,
        TileSquarePeekImageAndText04,
        TileSquareText01,
        TileSquareText02,
        TileSquareText03,
        TileSquareText04,
        TileWideBlockAndText01,
        TileWideBlockAndText02,
        TileWideImage,
        TileWideImageAndText01,
        TileWideImageAndText02,
        TileWideImageCollection,
        TileWidePeekImage01,
        TileWidePeekImage02,
        TileWidePeekImage03,
        TileWidePeekImage04,
        TileWidePeekImage05,
        TileWidePeekImage06,
        TileWidePeekImageAndText01,
        TileWidePeekImageAndText02,
        TileWidePeekImageCollection01,
        TileWidePeekImageCollection02,
        TileWidePeekImageCollection03,
        TileWidePeekImageCollection04,
        TileWidePeekImageCollection05,
        TileWidePeekImageCollection06,
        TileWideSmallImageAndText01,
        TileWideSmallImageAndText02,
        TileWideSmallImageAndText03,
        TileWideSmallImageAndText04,
        TileWideSmallImageAndText05,
        TileWideText01,
        TileWideText02,
        TileWideText03,
        TileWideText04,
        TileWideText05,
        TileWideText06,
        TileWideText07,
        TileWideText08,
        TileWideText09,
        TileWideText10,
        TileWideText11
    }
}