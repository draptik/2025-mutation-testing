#!/bin/sh

# Invoke from this folder, otherwise change target location (`-o "..."`)
# Also adopt URL (last parameter)...

#qrencode -s 6 -l H -o "../public/images/slides.png" "https://draptik.github.io/2025-05-md-devdays-mutation-testing/"
qrencode -s 6 -l H -o "../public/images/slides-codebuzz25.png" "https://draptik.github.io/2025-06-codebuzz-mutation-testing/"
