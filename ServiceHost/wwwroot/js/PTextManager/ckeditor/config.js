CKEDITOR.editorConfig = function( config ) {
	   config.uiColor = '#AADC6E';
    config.language = 'fa';
    CKEDITOR.config.allowedContent = true;
    config.contentsCss = '/js/PTextManager/ckeditor/Resource/fonts.css';
    config.font_names = 'Web_Yekan;IranText;IranYekanEXBold;IranSans;YekanLight;IranianSans;Vazir;IranNastaliq;' + config.font_names;




};
