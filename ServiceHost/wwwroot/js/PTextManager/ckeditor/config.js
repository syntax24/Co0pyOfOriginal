CKEDITOR.editorConfig = function( config ) {
	   config.uiColor = '#AADC6E';
    config.language = 'fa';
    CKEDITOR.config.allowedContent = true;
    config.contentsCss = '/js/PTextManager/ckeditor/Resource/fonts.css';
    config.font_names = 'Web_Yekan;IranText;IranYekanEXBold;IranSans;YekanLight;IranianSans;Vazir;IranNastaliq;' + config.font_names;
    config.font_defaultLabel = 'Web_Yekan';
    config.fontSize_defaultLabel = '18px';

    //config.font_style =
    //{
    //    element: 'span',
    //    styles: { 'font-family': '#Web_Yekan' },
    //    overrides: [{ element: 'font', attributes: { 'face': null } }]
    //};
  
//CKEDITOR.dialog.add("createfootnotes", editor => footnotesDialog(editor));
//CKEDITOR.dialog.add("editfootnotes", editor => footnotesDialog(editor, 1));
};

