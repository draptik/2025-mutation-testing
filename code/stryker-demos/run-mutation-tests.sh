#!/bin/sh
#
# Sometimes the IDE (f.ex. Rider) doesn't catch up quickly enough so it's easier to run 
# `dotnet clean` after running `dotnet stryker`.
#
# TODO Figure out what the problem is.
#
dotnet stryker --open-report:html && dotnet clean
