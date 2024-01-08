import cv2 as cv
import numpy as np
import helper as helper
import json

redPixelThresh = [120, 21, 21]
greenPixelThresh = [21, 120, 21]
bluePixelThresh = [21, 21, 120]
cyanPixelThresh = [21, 120, 120]
yellowPixelThresh = [120, 120, 21]
purpPixelThresh = [120, 21, 120]
whitePixelThresh = [200, 200, 200]
spiceImage = cv.imread("StarscapeMapSpice.png", cv.IMREAD_COLOR)
spiceImage = cv.cvtColor(spiceImage, cv.COLOR_BGR2RGB)
(height, width, depth) = spiceImage.shape
pixelCoordinateList = [( "", width, height)]  # color as string, pixelx, pixelY

try:
    for pixelX in range(width):  #  no :sleeping_accomodation:
        for pixelY in range(height):
            (pixelR, pixelG, pixelB) = spiceImage[pixelY, pixelX]
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=redPixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "Red"
            ):  # red
                print("Found Red Pixel At: " + str([pixelX, pixelY]))
            #
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=greenPixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "Green"
            ):  # red
                print("Found Green Pixel At: " + str([pixelX, pixelY]))
            #
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=bluePixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "Blue"
            ):  # red
                print("Found Blue Pixel At: " + str([pixelX, pixelY]))
            #
            # combined colors
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=cyanPixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "Orange"
            ):  # red
                print("Found Orange Pixel At: " + str([pixelX, pixelY]))
            #
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=yellowPixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "Yellow"
            ):  # red
                print("Found Yellow Pixel At: " + str([pixelX, pixelY]))
            #
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=purpPixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "Purple"
            ):  # red
                print("Found Purple Pixel At: " + str([pixelX, pixelY]))
            #
            # white
            if (
                helper.helper.CheckPixelThreshold(
                    thresholdValues=whitePixelThresh,
                    pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
                    pixelCoordinateList=pixelCoordinateList,
                )
                == "White"
            ):  # red
                print("Found White Pixel At: " + str([pixelX, pixelY]))
            #
        #
finally:
    pixelCoordinateList = list(set(pixelCoordinateList))

    actualPrintList = [("", -1, -1)]

    for colorString, coordinateX, coordinateY in pixelCoordinateList:
        if colorString != "":
            actualPrintList.append((colorString, coordinateX, coordinateY))

    testDict = {"SystemList": actualPrintList}
    with open("SystemDataOutput.json", mode="w") as file:
        json.dump(testDict, file, indent=4)
    #
