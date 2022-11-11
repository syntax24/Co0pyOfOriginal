
    const config = {
        height: '700px',
        };
//config.removeButtons = 'Language,Format,Styles,Source,Save,Templates,NewPage,Preview,PasteText,Paste,Cut,Undo,PasteFromWord,Replace,Find,About,Image,Flash,Smiley,SpecialChar,Iframe,RemoveFormat,CopyFormatting,Strike,Subscript,Superscript,Checkbox,TextField,Textarea,Select,Button,HiddenField,Scayt,SelectAll,Redo,Copy,Radio,Form,ImageButton,Link,Unlink,HorizontalRule,Anchor,ShowBlocks,PageBreak';
    const editor = document.getElementById("Description");

       CKEDITOR.replace(editor, config);

  /*  let ed = CKEDITOR.replace(editor, config);*/

CKEDITOR.on('dialogDefinition', function (e) {
    dilogName = e.data.name;
    dialogDefinition = e.data.definition;
    console.log(dialogDefinition);
})
//    ed.addCommand('docImageCommand', {
//        exec: function (event) {
//                var iframe = document.querySelector('#cke_1_contents iframe');
//    var cke_doc = iframe.contentDocument || iframe.contentWindow.document;
//    cke_doc.body.style = `height: 22cm;border: 3px solid #626262;
//    margin: 1.5cm 1cm 2cm 1cm;
//    padding:5px;
//    border-radius: 14px;`

//            }
            
//        });
//    ed.ui.addButton('addDocImage', {
//        label: 'ad text',
//    command: 'docImageCommand',
//    toolbar: 'insert',
//        icon: '/js/PTextManager/ckeditor/icon/square-outline.png',
//        });
//    ed.addCommand('docImageCommand1', {
//        exec: function (event) {
//                var iframe = document.querySelector('#cke_1_contents iframe');
//    var cke_doc = iframe.contentDocument || iframe.contentWindow.document;
//            cke_doc.body.style = `height: 21cm;border: 3px solid #626262;
//    margin: 2cm 1.5cm 2.5cm 1.5cm;
//    padding:5px;
//    border-radius: 14px;`
//            }

//        });

//    ed.ui.addButton('addDocImage1', {
//        label: 'ad textoio',
//    command: 'docImageCommand1',
//    toolbar: 'insert',
//        icon: '/js/PTextManager/ckeditor/icon/square-outline.png',
//    });


//ed.addCommand('docImageCommand2', {
//    exec: function (event) {
//        var iframe = document.querySelector('#cke_1_contents iframe');
//        var cke_doc = iframe.contentDocument || iframe.contentWindow.document;
//        cke_doc.body.style = `height: 21cm;border: 3px solid #626262;
//    margin: 2cm 1.5cm 2.5cm 1.5cm;
//    padding:5px;
//    border-radius: 14px;`
//    }

//});

//ed.ui.addButton('addDocImage2', {
//    label: 'ad textoio',
//    command: 'docImageCommand2',
//    toolbar: 'insert',
//    icon: '/js/PTextManager/ckeditor/icon/transparency.png',});




