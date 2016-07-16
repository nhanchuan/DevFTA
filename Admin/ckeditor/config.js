/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';



    config.filebrowserBrowseUrl = '/Admin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Admin/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Admin/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files&currentFolder=/images/Uploads/';
    config.filebrowserImageUploadUrl = '/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images&currentFolder=/images/Uploads/';
    config.filebrowserFlashUploadUrl = '/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
