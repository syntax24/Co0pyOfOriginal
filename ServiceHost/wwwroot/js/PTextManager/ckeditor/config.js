CKEDITOR.editorConfig = function( config ) {
	
    config.language = 'fa';
    CKEDITOR.config.allowedContent = true;
    config.contentsCss = '/AdminTheme/fonts/font-yekan-number-ronakweb/style.css';
    //the next line add the new font to the combobox in CKEditor
    config.font_names = 'ADuel;AShams;yekan;BRoze;Besmellah1;Besmellah2;Besmellah3;Besmellah4;Besmellah5;BTehran;DastNevis;Digital;Edo;Entezar;GeorgiaB;GeorgiaI;GeorgiaZ;IranNastaliq;Roze;Splash;SaginawBold;' + config.font_names;
};
