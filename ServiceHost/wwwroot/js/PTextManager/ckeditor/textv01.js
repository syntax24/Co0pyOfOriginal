
const config = {
    height: '700px',
};
config.removeButtons = 'Save,Source,NewPage,Preview,PasteText,Paste,Copy,Cut,PasteFromWord,Undo,Redo,Replace,Find,SelectAll,Scayt,Checkbox,Radio,TextField,Textarea,Button,ImageButton,HiddenField,Form,Strike,Subscript,Superscript,RemoveFormat,CopyFormatting,Outdent,Indent,CreateDiv,Blockquote,BidiLtr,BidiRtl,Language,Anchor,Link,Image,Flash,Table,Smiley,SpecialChar,PageBreak,HorizontalRule,Iframe,Format,Styles,ShowBlocks,About,Select,Unlink,BGColor,TextColor';
const editor = document.getElementById("Description");
shouldNotGroupWhenFull: true
CKEDITOR.config.font_defaultLabel = 'Web_Yekan';
CKEDITOR.config.fontSize_defaultLabel = '18';
config.format_tags = 'h2;h3;h4;h5;h6;pre;address;div';
let ed = CKEDITOR.replace(editor, config);
CKEDITOR.on('dialogDefinition', function (e) {
    dilogName = e.data.name;
    dialogDefinition = e.data.definition;
    console.log(dialogDefinition);
})
ed.addCommand('docImageCommand', {
    exec: function (event) {
        document.getElementById('btnPopModal').click();
    }
});

  
/*CKEDITOR.dialog.add('docImageCommand', this.path + 'dialogs/abbr.js');*/
ed.ui.addButton('placeholder', {
    label: 'جستجوی متن',
    size: 500,
    command: 'docImageCommand',
    toolbar: 'insert',
//    icon: '/js/PTextManager/ckeditor/icon/searchtext.png',
});
//ed.ui.addButton(document.querySelector('#editor'))
//    .then(editor => {
//        editor.ui.view.toolbar.items.get(0).label = 'YEAH BUDDY'
//    });


