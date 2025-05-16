window.printHtml = function (htmlContent) {
    // Create a new window
    const printWindow = window.open('', '_blank');

    // Ensure the window was created
    if (!printWindow) {
        alert("Please allow pop-ups for printing.");
        return;
    }

    // Create a minimal, clean document for printing
    printWindow.document.write(`
        <!DOCTYPE html>
        <html>
        <head>
            <title>Print</title>
            <style>
                @import url('https://fonts.googleapis.com/css2?family=Roboto+Mono:wght@400;500;700&display=swap');
                body { 
                    font-family: 'Roboto Mono', monospace;
                    margin: 20px; 
                    white-space: nowrap;
                    overflow-x: visible;
                    width: auto;
                    max-width: none;
                }
                pre, code { 
                    font-family: 'Courier New', monospace; 
                    white-space: pre; 
                }
                @media print {
                    @page { margin: 1cm; }
                }
                .page-break {
                    page-break-before: always; /* Legacy */
                    break-before: page; /* Modern browsers */
                }
            </style>
        </head>
        <body>
            ${htmlContent}
        </body>
        </html>
    `);


    // Finish writing and prepare for printing
    printWindow.document.close();

    // Wait for content to load, then print
    printWindow.onload = function () {
        printWindow.print();
        // Close the window after printing
        printWindow.onafterprint = function () {
            printWindow.close();
        };
    };
};