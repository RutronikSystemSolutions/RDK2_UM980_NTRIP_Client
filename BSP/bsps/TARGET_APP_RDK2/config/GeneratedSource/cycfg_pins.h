/*******************************************************************************
* File Name: cycfg_pins.h
*
* Description:
* Pin configuration
* This file was automatically generated and should not be modified.
* Configurator Backend 3.0.0
* device-db 4.7.0.4251
* mtb-pdl-cat1 3.7.0.27344
*
********************************************************************************
* Copyright 2023 Cypress Semiconductor Corporation (an Infineon company) or
* an affiliate of Cypress Semiconductor Corporation.
* SPDX-License-Identifier: Apache-2.0
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
********************************************************************************/

#if !defined(CYCFG_PINS_H)
#define CYCFG_PINS_H

#include "cycfg_notices.h"
#include "cy_gpio.h"
#include "cycfg_routing.h"
#if defined (CY_USING_HAL)
    #include "cyhal_hwmgr.h"
#endif //defined (CY_USING_HAL)
#include "cy_smartio.h"

#if defined(__cplusplus)
extern "C" {
#endif

#define WCO_IN_ENABLED 1U
#define WCO_IN_PORT GPIO_PRT0
#define WCO_IN_PORT_NUM 0U
#define WCO_IN_PIN 0U
#define WCO_IN_NUM 0U
#define WCO_IN_DRIVEMODE CY_GPIO_DM_ANALOG
#define WCO_IN_INIT_DRIVESTATE 1
#ifndef ioss_0_port_0_pin_0_HSIOM
    #define ioss_0_port_0_pin_0_HSIOM HSIOM_SEL_GPIO
#endif
#define WCO_IN_HSIOM ioss_0_port_0_pin_0_HSIOM
#define WCO_IN_IRQ ioss_interrupts_gpio_0_IRQn
#if defined (CY_USING_HAL)
    #define WCO_IN_HAL_PORT_PIN P0_0
    #define WCO_IN P0_0
    #define WCO_IN_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define WCO_IN_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define WCO_IN_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
#endif //defined (CY_USING_HAL)
#define WCO_OUT_ENABLED 1U
#define WCO_OUT_PORT GPIO_PRT0
#define WCO_OUT_PORT_NUM 0U
#define WCO_OUT_PIN 1U
#define WCO_OUT_NUM 1U
#define WCO_OUT_DRIVEMODE CY_GPIO_DM_ANALOG
#define WCO_OUT_INIT_DRIVESTATE 1
#ifndef ioss_0_port_0_pin_1_HSIOM
    #define ioss_0_port_0_pin_1_HSIOM HSIOM_SEL_GPIO
#endif
#define WCO_OUT_HSIOM ioss_0_port_0_pin_1_HSIOM
#define WCO_OUT_IRQ ioss_interrupts_gpio_0_IRQn
#if defined (CY_USING_HAL)
    #define WCO_OUT_HAL_PORT_PIN P0_1
    #define WCO_OUT P0_1
    #define WCO_OUT_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define WCO_OUT_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define WCO_OUT_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
    #define ARDU_RX (P0_2)
    #define CYBSP_D6 ARDU_RX
    #define ARDU_TX (P0_3)
    #define CYBSP_D7 ARDU_TX
    #define ARDU_IO7 (P0_4)
    #define CYBSP_D8 ARDU_IO7
    #define ARDU_IO8 (P0_5)
    #define CYBSP_D9 ARDU_IO8
    #define ARDU_ADC1 (P10_0)
    #define CYBSP_A0 ARDU_ADC1
    #define ARDU_ADC2 (P10_1)
    #define CYBSP_A1 ARDU_ADC2
    #define ARDU_ADC3 (P10_2)
    #define CYBSP_A2 ARDU_ADC3
    #define ARDU_ADC4 (P10_3)
    #define CYBSP_A3 ARDU_ADC4
    #define POT_ADC (P10_4)
    #define CYBSP_A4 POT_ADC
    #define CYBSP_POT POT_ADC
    #define BAT_ADC (P10_5)
    #define CYBSP_A5 BAT_ADC
    #define ARDU_IO5 (P10_6)
    #define CYBSP_A6 ARDU_IO5
    #define ARDU_IO6 (P10_7)
    #define CYBSP_A7 ARDU_IO6
    #define ARDU_IO4 (P11_0)
    #define CYBSP_D5 ARDU_IO4
    #define FLASH_SSEL (P11_1)
    #define CYBSP_QSPI_SS FLASH_SSEL
    #define CYBSP_QSPI_FLASH_SSEL FLASH_SSEL
    #define PSRAM_SSEL (P11_2)
    #define QSPI_IO3 (P11_3)
    #define CYBSP_QSPI_D3 QSPI_IO3
    #define QSPI_IO2 (P11_4)
    #define CYBSP_QSPI_D2 QSPI_IO2
    #define QSPI_IO1 (P11_5)
    #define CYBSP_QSPI_D1 QSPI_IO1
    #define QSPI_IO0 (P11_6)
    #define CYBSP_QSPI_D0 QSPI_IO0
    #define QSPI_CLK (P11_7)
    #define CYBSP_QSPI_SCK QSPI_CLK
    #define ARDU_SCL (P12_0)
    #define CYBSP_I2C_SCL ARDU_SCL
    #define ARDU_SDA (P12_1)
    #define CYBSP_I2C_SDA ARDU_SDA
#endif //defined (CY_USING_HAL)
#define ECO_IN_ENABLED 1U
#define ECO_IN_PORT GPIO_PRT12
#define ECO_IN_PORT_NUM 12U
#define ECO_IN_PIN 6U
#define ECO_IN_NUM 6U
#define ECO_IN_DRIVEMODE CY_GPIO_DM_ANALOG
#define ECO_IN_INIT_DRIVESTATE 1
#ifndef ioss_0_port_12_pin_6_HSIOM
    #define ioss_0_port_12_pin_6_HSIOM HSIOM_SEL_GPIO
#endif
#define ECO_IN_HSIOM ioss_0_port_12_pin_6_HSIOM
#define ECO_IN_IRQ ioss_interrupts_gpio_12_IRQn
#if defined (CY_USING_HAL)
    #define ECO_IN_HAL_PORT_PIN P12_6
    #define ECO_IN P12_6
    #define ECO_IN_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define ECO_IN_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define ECO_IN_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
#endif //defined (CY_USING_HAL)
#define ECO_OUT_ENABLED 1U
#define ECO_OUT_PORT GPIO_PRT12
#define ECO_OUT_PORT_NUM 12U
#define ECO_OUT_PIN 7U
#define ECO_OUT_NUM 7U
#define ECO_OUT_DRIVEMODE CY_GPIO_DM_ANALOG
#define ECO_OUT_INIT_DRIVESTATE 1
#ifndef ioss_0_port_12_pin_7_HSIOM
    #define ioss_0_port_12_pin_7_HSIOM HSIOM_SEL_GPIO
#endif
#define ECO_OUT_HSIOM ioss_0_port_12_pin_7_HSIOM
#define ECO_OUT_IRQ ioss_interrupts_gpio_12_IRQn
#if defined (CY_USING_HAL)
    #define ECO_OUT_HAL_PORT_PIN P12_7
    #define ECO_OUT P12_7
    #define ECO_OUT_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define ECO_OUT_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define ECO_OUT_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
#endif //defined (CY_USING_HAL)
#define USB_DP_ENABLED 1U
#define USB_DP_PORT GPIO_PRT14
#define USB_DP_PORT_NUM 14U
#define USB_DP_PIN 0U
#define USB_DP_NUM 0U
#define USB_DP_DRIVEMODE CY_GPIO_DM_ANALOG
#define USB_DP_INIT_DRIVESTATE 1
#ifndef ioss_0_port_14_pin_0_HSIOM
    #define ioss_0_port_14_pin_0_HSIOM HSIOM_SEL_GPIO
#endif
#define USB_DP_HSIOM ioss_0_port_14_pin_0_HSIOM
#define USB_DP_IRQ ioss_interrupts_gpio_14_IRQn
#if defined (CY_USING_HAL)
    #define USB_DP_HAL_PORT_PIN P14_0
    #define USB_DP P14_0
    #define USB_DP_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define USB_DP_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define USB_DP_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
#endif //defined (CY_USING_HAL)
#define USB_DM_ENABLED 1U
#define USB_DM_PORT GPIO_PRT14
#define USB_DM_PORT_NUM 14U
#define USB_DM_PIN 1U
#define USB_DM_NUM 1U
#define USB_DM_DRIVEMODE CY_GPIO_DM_ANALOG
#define USB_DM_INIT_DRIVESTATE 1
#ifndef ioss_0_port_14_pin_1_HSIOM
    #define ioss_0_port_14_pin_1_HSIOM HSIOM_SEL_GPIO
#endif
#define USB_DM_HSIOM ioss_0_port_14_pin_1_HSIOM
#define USB_DM_IRQ ioss_interrupts_gpio_14_IRQn
#if defined (CY_USING_HAL)
    #define USB_DM_HAL_PORT_PIN P14_1
    #define USB_DM P14_1
    #define USB_DM_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define USB_DM_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define USB_DM_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
    #define uSD_DAT0 (P2_0)
    #define CYBSP_SDHC_IO0 uSD_DAT0
    #define uSD_DAT1 (P2_1)
    #define CYBSP_SDHC_IO1 uSD_DAT1
    #define uSD_DAT2 (P2_2)
    #define CYBSP_SDHC_IO2 uSD_DAT2
    #define uSD_DAT3 (P2_3)
    #define CYBSP_SDHC_IO3 uSD_DAT3
    #define uSD_CMD (P2_4)
    #define CYBSP_SDHC_CMD uSD_CMD
    #define uSD_CLK (P2_5)
    #define CYBSP_SDHC_CLK uSD_CLK
    #define uSD_DETECT (P2_6)
    #define CYBSP_SDHC_DETECT uSD_DETECT
    #define ARDU_IO1 (P2_7)
    #define CYBSP_D4 ARDU_IO1
    #define KITPROG_RX (P3_0)
    #define CYBSP_DEBUG_UART_RX KITPROG_RX
    #define KITPROG_TX (P3_1)
    #define CYBSP_DEBUG_UART_TX KITPROG_TX
    #define CANFD_RX (P5_0)
    #define CYBSP_D0 CANFD_RX
    #define CANFD_TX (P5_1)
    #define CYBSP_D1 CANFD_TX
    #define ARDU_IO2 (P5_6)
    #define P5_2 ARDU_IO2
    #define CYBSP_D2 ARDU_IO2
    #define ARDU_IO3 (P5_7)
    #define P5_3 ARDU_IO3
    #define CYBSP_D3 ARDU_IO3
    #define RS485_RX (P6_0)
    #define CYBSP_D14 RS485_RX
    #define RS485_TX (P6_1)
    #define CYBSP_D15 RS485_TX
    #define CANFD_STB (P6_2)
    #define RS485_DE (P6_3)
#endif //defined (CY_USING_HAL)
#define TDO_SWO_ENABLED 1U
#define CYBSP_SWO_ENABLED TDO_SWO_ENABLED
#define TDO_SWO_PORT GPIO_PRT6
#define CYBSP_SWO_PORT TDO_SWO_PORT
#define TDO_SWO_PORT_NUM 6U
#define CYBSP_SWO_PORT_NUM TDO_SWO_PORT_NUM
#define TDO_SWO_PIN 4U
#define CYBSP_SWO_PIN TDO_SWO_PIN
#define TDO_SWO_NUM 4U
#define CYBSP_SWO_NUM TDO_SWO_NUM
#define TDO_SWO_DRIVEMODE CY_GPIO_DM_ANALOG
#define CYBSP_SWO_DRIVEMODE TDO_SWO_DRIVEMODE
#define TDO_SWO_INIT_DRIVESTATE 1
#define CYBSP_SWO_INIT_DRIVESTATE TDO_SWO_INIT_DRIVESTATE
#ifndef ioss_0_port_6_pin_4_HSIOM
    #define ioss_0_port_6_pin_4_HSIOM HSIOM_SEL_GPIO
#endif
#define TDO_SWO_HSIOM ioss_0_port_6_pin_4_HSIOM
#define CYBSP_SWO_HSIOM TDO_SWO_HSIOM
#define TDO_SWO_IRQ ioss_interrupts_gpio_6_IRQn
#define CYBSP_SWO_IRQ TDO_SWO_IRQ
#if defined (CY_USING_HAL)
    #define TDO_SWO_HAL_PORT_PIN P6_4
    #define CYBSP_SWO_HAL_PORT_PIN TDO_SWO_HAL_PORT_PIN
    #define TDO_SWO P6_4
    #define CYBSP_SWO TDO_SWO
    #define TDO_SWO_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define CYBSP_SWO_HAL_IRQ TDO_SWO_HAL_IRQ
    #define TDO_SWO_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define CYBSP_SWO_HAL_DIR TDO_SWO_HAL_DIR
    #define TDO_SWO_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
    #define CYBSP_SWO_HAL_DRIVEMODE TDO_SWO_HAL_DRIVEMODE
#endif //defined (CY_USING_HAL)
#define TDI_ENABLED 1U
#define TDI_PORT GPIO_PRT6
#define TDI_PORT_NUM 6U
#define TDI_PIN 5U
#define TDI_NUM 5U
#define TDI_DRIVEMODE CY_GPIO_DM_ANALOG
#define TDI_INIT_DRIVESTATE 1
#ifndef ioss_0_port_6_pin_5_HSIOM
    #define ioss_0_port_6_pin_5_HSIOM HSIOM_SEL_GPIO
#endif
#define TDI_HSIOM ioss_0_port_6_pin_5_HSIOM
#define TDI_IRQ ioss_interrupts_gpio_6_IRQn
#if defined (CY_USING_HAL)
    #define TDI_HAL_PORT_PIN P6_5
    #define TDI P6_5
    #define TDI_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define TDI_HAL_DIR CYHAL_GPIO_DIR_INPUT 
    #define TDI_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_ANALOG
#endif //defined (CY_USING_HAL)
#define SWDIO_ENABLED 1U
#define CYBSP_SWDIO_ENABLED SWDIO_ENABLED
#define SWDIO_PORT GPIO_PRT6
#define CYBSP_SWDIO_PORT SWDIO_PORT
#define SWDIO_PORT_NUM 6U
#define CYBSP_SWDIO_PORT_NUM SWDIO_PORT_NUM
#define SWDIO_PIN 6U
#define CYBSP_SWDIO_PIN SWDIO_PIN
#define SWDIO_NUM 6U
#define CYBSP_SWDIO_NUM SWDIO_NUM
#define SWDIO_DRIVEMODE CY_GPIO_DM_PULLUP
#define CYBSP_SWDIO_DRIVEMODE SWDIO_DRIVEMODE
#define SWDIO_INIT_DRIVESTATE 1
#define CYBSP_SWDIO_INIT_DRIVESTATE SWDIO_INIT_DRIVESTATE
#ifndef ioss_0_port_6_pin_6_HSIOM
    #define ioss_0_port_6_pin_6_HSIOM HSIOM_SEL_GPIO
#endif
#define SWDIO_HSIOM ioss_0_port_6_pin_6_HSIOM
#define CYBSP_SWDIO_HSIOM SWDIO_HSIOM
#define SWDIO_IRQ ioss_interrupts_gpio_6_IRQn
#define CYBSP_SWDIO_IRQ SWDIO_IRQ
#if defined (CY_USING_HAL)
    #define SWDIO_HAL_PORT_PIN P6_6
    #define CYBSP_SWDIO_HAL_PORT_PIN SWDIO_HAL_PORT_PIN
    #define SWDIO P6_6
    #define CYBSP_SWDIO SWDIO
    #define SWDIO_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define CYBSP_SWDIO_HAL_IRQ SWDIO_HAL_IRQ
    #define SWDIO_HAL_DIR CYHAL_GPIO_DIR_BIDIRECTIONAL 
    #define CYBSP_SWDIO_HAL_DIR SWDIO_HAL_DIR
    #define SWDIO_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_PULLUP
    #define CYBSP_SWDIO_HAL_DRIVEMODE SWDIO_HAL_DRIVEMODE
#endif //defined (CY_USING_HAL)
#define SWCLK_ENABLED 1U
#define CYBSP_SWCLK_ENABLED SWCLK_ENABLED
#define SWCLK_PORT GPIO_PRT6
#define CYBSP_SWCLK_PORT SWCLK_PORT
#define SWCLK_PORT_NUM 6U
#define CYBSP_SWCLK_PORT_NUM SWCLK_PORT_NUM
#define SWCLK_PIN 7U
#define CYBSP_SWCLK_PIN SWCLK_PIN
#define SWCLK_NUM 7U
#define CYBSP_SWCLK_NUM SWCLK_NUM
#define SWCLK_DRIVEMODE CY_GPIO_DM_PULLDOWN
#define CYBSP_SWCLK_DRIVEMODE SWCLK_DRIVEMODE
#define SWCLK_INIT_DRIVESTATE 1
#define CYBSP_SWCLK_INIT_DRIVESTATE SWCLK_INIT_DRIVESTATE
#ifndef ioss_0_port_6_pin_7_HSIOM
    #define ioss_0_port_6_pin_7_HSIOM HSIOM_SEL_GPIO
#endif
#define SWCLK_HSIOM ioss_0_port_6_pin_7_HSIOM
#define CYBSP_SWCLK_HSIOM SWCLK_HSIOM
#define SWCLK_IRQ ioss_interrupts_gpio_6_IRQn
#define CYBSP_SWCLK_IRQ SWCLK_IRQ
#if defined (CY_USING_HAL)
    #define SWCLK_HAL_PORT_PIN P6_7
    #define CYBSP_SWCLK_HAL_PORT_PIN SWCLK_HAL_PORT_PIN
    #define SWCLK P6_7
    #define CYBSP_SWCLK SWCLK
    #define SWCLK_HAL_IRQ CYHAL_GPIO_IRQ_NONE
    #define CYBSP_SWCLK_HAL_IRQ SWCLK_HAL_IRQ
    #define SWCLK_HAL_DIR CYHAL_GPIO_DIR_BIDIRECTIONAL 
    #define CYBSP_SWCLK_HAL_DIR SWCLK_HAL_DIR
    #define SWCLK_HAL_DRIVEMODE CYHAL_GPIO_DRIVE_PULLDOWN
    #define CYBSP_SWCLK_HAL_DRIVEMODE SWCLK_HAL_DRIVEMODE
    #define CS1 (P7_0)
    #define CYBSP_CSD_SLD0 CS1
    #define CYBSP_CS_SLD0 CS1
    #define CINTA (P7_1)
    #define CYBSP_CINA CINTA
    #define CYBSP_CMOD CINTA
    #define CINTB (P7_2)
    #define CYBSP_CINB CINTB
    #define CS2 (P7_3)
    #define CYBSP_CSD_SLD1 CS2
    #define CYBSP_CS_SLD1 CS2
    #define CS3 (P7_4)
    #define CYBSP_CSD_SLD2 CS3
    #define CYBSP_CS_SLD2 CS3
    #define CS4 (P7_5)
    #define CYBSP_CSD_SLD3 CS4
    #define CYBSP_CS_SLD3 CS4
    #define CS5 (P7_6)
    #define CYBSP_CSD_SLD4 CS5
    #define CYBSP_CS_SLD4 CS5
    #define CS_TX (P7_7)
    #define CYBSP_CS_TX_RX CS_TX
    #define ARDU_MOSI (P8_0)
    #define CYBSP_SPI_MOSI ARDU_MOSI
    #define CYBSP_D11 ARDU_MOSI
    #define ARDU_MISO (P8_1)
    #define CYBSP_SPI_MISO ARDU_MISO
    #define CYBSP_D12 ARDU_MISO
    #define ARDU_CLK (P8_2)
    #define CYBSP_SPI_CLK ARDU_CLK
    #define CYBSP_D13 ARDU_CLK
    #define ARDU_CS (P8_3)
    #define CYBSP_SPI_CS ARDU_CS
    #define CYBSP_D10 ARDU_CS
#endif //defined (CY_USING_HAL)
#define ioss_0_port_8_smartio_0_ENABLED 1U
#define ioss_0_port_8_smartio_0_HW SMARTIO_PRT8
#if defined (CY_USING_HAL)
    #define LED1 (P9_0)
    #define CYBSP_USER_LED LED1
    #define CYBSP_USER_LED1 LED1
    #define LED2 (P9_1)
    #define CYBSP_USER_LED2 LED2
    #define USER_BTN2 (P9_2)
    #define CYBSP_USER_BTN2 USER_BTN2
    #define USER_BTN1 (P9_3)
    #define CYBSP_USER_BTN_DRIVE USER_BTN1
    #define CYBSP_USER_BTN USER_BTN1
    #define CYBSP_USER_BTN1 USER_BTN1
#endif //defined (CY_USING_HAL)

extern const cy_stc_gpio_pin_config_t WCO_IN_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t WCO_IN_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t WCO_OUT_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t WCO_OUT_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t ECO_IN_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t ECO_IN_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t ECO_OUT_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t ECO_OUT_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t USB_DP_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t USB_DP_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t USB_DM_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t USB_DM_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t TDO_SWO_config;
#define CYBSP_SWO_config TDO_SWO_config
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t TDO_SWO_obj;
    #define CYBSP_SWO_obj TDO_SWO_obj
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t TDI_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t TDI_obj;
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t SWDIO_config;
#define CYBSP_SWDIO_config SWDIO_config
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t SWDIO_obj;
    #define CYBSP_SWDIO_obj SWDIO_obj
#endif //defined (CY_USING_HAL)
extern const cy_stc_gpio_pin_config_t SWCLK_config;
#define CYBSP_SWCLK_config SWCLK_config
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t SWCLK_obj;
    #define CYBSP_SWCLK_obj SWCLK_obj
#endif //defined (CY_USING_HAL)
extern const cy_stc_smartio_config_t ioss_0_port_8_smartio_0_config;

void init_cycfg_pins(void);
void reserve_cycfg_pins(void);

#if defined(__cplusplus)
}
#endif


#endif /* CYCFG_PINS_H */
