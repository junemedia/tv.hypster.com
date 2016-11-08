


$(document).ready(function () {

    $(".mRegister").bind('mouseenter', function () {
        $(".mRegister").css("background-image", "url(/imgs/nav_link_over.gif)");
    });
    $(".mRegister").bind('mouseout', function () {
        $(".mRegister").css("background-image", "url(/imgs/menu_back.png)");
    });


    $(".mSearchMusic").bind('mouseenter', function () {
        $(".mSearchMusic").css("background-image", "url(/imgs/nav_link_over.gif)");
    });
    $(".mSearchMusic").bind('mouseout', function () {
        $(".mSearchMusic").css("background-image", "url(/imgs/menu_back.png)");
    });


    $(".mFindFriends").bind('mouseenter', function () {
        $(".mFindFriends").css("background-image", "url(/imgs/nav_link_over.gif)");
    });
    $(".mFindFriends").bind('mouseout', function () {
        $(".mFindFriends").css("background-image", "url(/imgs/menu_back.png)");
    });


//    $(".mHypsterTV").bind('mouseenter', function () {
//        $(".mHypsterTV").css("background-image", "url(/imgs/nav_link_over.gif)");
//    });
//    $(".mHypsterTV").bind('mouseout', function () {
//        $(".mHypsterTV").css("background-image", "url(/imgs/menu_back.png)");
//    });
    //$(".mHypsterTV").css("background-image", "url(/imgs/nav_link_over.gif)");



    $(".mMusicNews").bind('mouseenter', function () {
        $(".mMusicNews").css("background-image", "url(/imgs/nav_link_over.gif)");
    });
    $(".mMusicNews").bind('mouseout', function () {
        $(".mMusicNews").css("background-image", "url(/imgs/menu_back.png)");
    });




    //------------------------------------------------------------------------------------------------------------------
    $(".txtLogin").focus(function () {
        $(this).css("background-color", "#fdf1b0");
        $(this).css("font-weight", "bold");
    });

    $(".txtLogin").blur(function () {
        $(this).css("background-color", "#EEEEEE");
        $(this).css("font-weight", "normal");
    });
    //------------------------------------------------------------------------------------------------------------------


});












function switchVMenu(mnum) {
    if (mnum == 1) {
        //$("#vMenu1").css("background-color", "#555555");
        $("#vMenu1").css("background", "#555555 url('/imgs/box_back.png')");
        $("#vMenu2").css("background", "");

        $("#Tab_NewVideos").css("display", "none");
        $("#Tab_MostPopular").css("display", "block");
    }
    else {
        $("#vMenu1").css("background", "");
        //$("#vMenu2").css("background-color", "#555555");
        $("#vMenu2").css("background", "#555555 url('/imgs/box_back.png')");

        $("#Tab_MostPopular").css("display", "none");
        $("#Tab_NewVideos").css("display", "block");
    }
}     