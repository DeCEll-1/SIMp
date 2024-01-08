import cv2 as cv
import numpy as np


class helper:
    def CheckPixelThreshold(thresholdValues, pixel, pixelCoordinateList):
        result = ""

        (pixelRThresh, pixelGThresh, pixelBThresh) = thresholdValues

        (pixelR, pixelG, pixelB, pixelX, pixelY) = pixel

        if pixelR == 0 or pixelG == 0 or pixelB == 0:
            return None
        # this?

        rThreshPassed = False
        gThreshPassed = False
        bThreshPassed = False

        if pixelR > pixelRThresh:
            rThreshPassed = True
        if pixelG > pixelGThresh:
            gThreshPassed = True
        if pixelB > pixelBThresh:
            bThreshPassed = True

        if rThreshPassed and gThreshPassed and bThreshPassed:  #
            result = "White"
        #

        elif not rThreshPassed and gThreshPassed and bThreshPassed:
            result = "Orange"
        #

        elif rThreshPassed and gThreshPassed and not bThreshPassed:
            result = "Yellow"
        #

        elif rThreshPassed and not gThreshPassed and bThreshPassed:
            result = "Purple"
        #

        elif rThreshPassed and not gThreshPassed and not bThreshPassed:
            result = "Red"
        #

        elif not rThreshPassed and gThreshPassed and not bThreshPassed:
            result = "Green"
        #

        elif not rThreshPassed and not gThreshPassed and bThreshPassed:
            result = "Blue"
        #

        else:
            return None
        #

        # clonePixelCoordinateList = helper.CloneList(pixelCoordinateList)

        # clonePixelCoordinateList = helper.ReverseList(clonePixelCoordinateList)

        if False:
            pixelCoordinateList.append((result, pixelX, pixelY))

            return result
        #

        i = 0

        for coordinateIndex in range(len(pixelCoordinateList)):
            (colorString, coordinateX, coordinateY) = pixelCoordinateList[
                len(pixelCoordinateList) - 1 - coordinateIndex
            ]

            i += i
            if i == 7:
                return None
            # if result == colorString:
            if (
                pixelX - 1 == coordinateX or pixelX - 2 == coordinateX
            ):  # if the pixel next to curr pixel is already saved
                return None
            #
            elif (
                pixelX + 1 == coordinateX or pixelX + 2 == coordinateX
            ):  # if the pixel next to curr pixel is already saved
                return None
            #
            elif (
                pixelY - 1 == coordinateY or pixelY - 2 == coordinateY
            ):  # if the pixel next to curr pixel is already saved
                return None
            #
            elif (
                pixelY + 1 == coordinateY or pixelY + 2 == coordinateY
            ):  # if the pixel next to curr pixel is already saved
                return None
                #
            #
        #

        pixelCoordinateList.append((result, pixelX, pixelY))

        return result

    def CloneList(listToClone):
        list_copy = listToClone[:]
        return list_copy

    def ReverseList(listToReverse):
        reversedList = listToReverse[::-1]
        return reversedList
