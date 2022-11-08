
    const config = {
        height: '800px',
        };
    config.removeButtons = 'Format,Styles,Source,Save,Templates,NewPage,Preview,PasteText,Paste,Cut,Undo,PasteFromWord,Replace,Find,About,Image,Flash,Smiley,SpecialChar,Iframe,RemoveFormat,CopyFormatting,Strike,Subscript,Superscript,Checkbox,TextField,Textarea,Select,Button,HiddenField,Scayt,SelectAll,Redo,Copy,Radio,Form,ImageButton,Link,Unlink,HorizontalRule,Anchor,ShowBlocks,PageBreak';
    const editor = document.getElementById("Description");

    /*   CKEDITOR.replace(editor, config);*/

    let ed = CKEDITOR.replace(editor, config);

    ed.addCommand('docImageCommand', {
        exec: function (event) {
                var iframe = document.querySelector('#cke_1_contents iframe');
    var cke_doc = iframe.contentDocument || iframe.contentWindow.document;
    cke_doc.body.style = `height: 25cm;border: 3px solid #626262;
    margin: 5px;
    padding: 5px;
    border-radius: 14px;`

            }
            
        });
    ed.ui.addButton('addDocImage', {
        label: 'ad text',
    command: 'docImageCommand',
    toolbar: 'insert',
    icon: '/AdminTheme/LogoAndProfile/logo.png',
        });
    ed.addCommand('docImageCommand1', {
        exec: function (event) {
                var iframe = document.querySelector('#cke_1_contents iframe');
    var cke_doc = iframe.contentDocument || iframe.contentWindow.document;
    cke_doc.body.style = `height: 25cm;border: 3px solid #626262;
    margin: 0px;
    padding: 0px;
    border-radius: 14px;`
            }

        });

    ed.ui.addButton('addDocImage1', {
        label: 'ad textoio',
    command: 'docImageCommand1',
    toolbar: 'insert',
    icon: '/AdminTheme/LogoAndProfile/logo.png',
        });

