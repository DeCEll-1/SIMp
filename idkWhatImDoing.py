import cv2 as cv
import numpy as np
import helper as helper
import json


spiceImage = cv.imread("StarscapeMapSpiceThresholded.png", cv.IMREAD_COLOR)
# cv.imshow("spiceImage", spiceImage)
# cv.waitKey(1)
spiceImage = cv.cvtColor(spiceImage, cv.COLOR_BGR2RGB)


# yellowSpiceImage = cv.imread("YellowSpice.png", cv.IMREAD_COLOR)
# yellowSpiceImage = cv.cvtColor(yellowSpiceImage, cv.COLOR_BGR2RGB)
# cv.imshow("mahmud", yellowSpiceImage)


(height, width, depth) = spiceImage.shape
pixelCoordinateList = [("", width, height)]  # color as string, pixelx, pixelY


try:
    # region pixel
    # for pixelX in range(width):  #  no :sleeping_accomodation:
    #     for pixelY in range(height):
    #         (pixelR, pixelG, pixelB) = spiceImage[pixelY, pixelX]

    #         if (  # red
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "Red"
    #         ):
    #             print("Found Red Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #         if (  # green
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "Green"
    #         ):
    #             print("Found Green Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #         if (  # blue
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "Blue"
    #         ):
    #             print("Found Blue Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #         if (  # Cyan
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "Orange"
    #         ):
    #             print("Found Orange Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #         if (  # yellow
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "Yellow"
    #         ):
    #             print("Found Yellow Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #         if (  # purple
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "Purple"
    #         ):
    #             print("Found Purple Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #         if (  # white
    #             helper.helper.CheckPixelThreshold(
    #                 pixel=(pixelR, pixelG, pixelB, pixelX, pixelY),
    #                 pixelCoordinateList=pixelCoordinateList,
    #             )
    #             == "White"
    #         ):
    #             print("Found White Pixel At: " + str([pixelX, pixelY]))
    #             continue
    #         #

    #     #
    # endregion

    spiceGray = cv.cvtColor(spiceImage, cv.COLOR_BGR2GRAY)

    ret2, threshold = cv.threshold(spiceGray, 18, 255, cv.THRESH_BINARY)

    cv.imshow("threshold", threshold)

    (contours, hierarchy) = cv.findContours(
        threshold, cv.RETR_TREE, cv.CHAIN_APPROX_NONE
    )

    foundContours = np.ones(spiceImage.shape[:3], dtype="uint8") * 255

    cv.drawContours(foundContours, contours, -1, (0, 0, 255), 3)

    print("Contours: " + str(len(contours)))

    cv.imshow("contours", foundContours)

    for c in contours:
        (x, y, w, h) = cv.boundingRect(c)

        pixelCoordinateList.append(("White", x, y))

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


cv.waitKey(0)
