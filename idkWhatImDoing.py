import cv2 as cv
import numpy as np
import helper as helper
import json

redPixelThresh = [120, 20, 20]
greenPixelThresh = [20, 120, 20]
bluePixelThresh = [20, 20, 120]

orangePixelThresh = [120, 120, 20]
yellowPixelThresh = [200, 120, 20]
purpPixelThresh = [120, 20, 120]

whitePixelThresh = [200, 200, 200]

spiceImage = cv.imread("StarscapeMapSpice.png", cv.IMREAD_COLOR)
spiceImage = cv.cvtColor(spiceImage, cv.COLOR_BGR2RGB)

(height, width, depth) = spiceImage.shape

pixelCoordinateList = [["", -1, -1]]  # color as string, pixelx, pixelY
# yeah
# whats that
# forgor
# yeah?
# json objects?


for pixelX in range(0, width):  #  no :sleeping_accomodation:
    for pixelY in range(0, height):
        (pixelR, pixelG, pixelB) = spiceImage[pixelX, pixelY]

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
                thresholdValues=orangePixelThresh,
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


testDict = {"SystemList": pixelCoordinateList}

# what that does?
with open("SystemDataOutput.json") as file:
    json.dump(testDict, file, indent=4)
# ima play ss13 frfr
# space station 13
# watch sseths video on it
# 
# 
# 
