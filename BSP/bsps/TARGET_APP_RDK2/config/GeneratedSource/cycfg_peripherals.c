/*******************************************************************************
* File Name: cycfg_peripherals.c
*
* Description:
* Peripheral Hardware Block configuration
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

#include "cycfg_peripherals.h"

#define USB_DEV_INTR_LVL_SEL (CY_USBFS_DEV_DRV_SET_SOF_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_BUS_RESET_LVL(0x2U) | \
                 CY_USBFS_DEV_DRV_SET_EP0_LVL(0x2U) | \
                 CY_USBFS_DEV_DRV_SET_LPM_LVL(0x0U) | \
                 CY_USBFS_DEV_DRV_SET_ARB_EP_LVL(0x0U) | \
                 CY_USBFS_DEV_DRV_SET_EP1_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP2_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP3_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP4_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP5_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP6_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP7_LVL(0x1U) | \
                 CY_USBFS_DEV_DRV_SET_EP8_LVL(0x1U))

const cy_stc_usbfs_dev_drv_config_t USB_DEV_config = 
{
    .mode = CY_USBFS_DEV_DRV_EP_MANAGEMENT_CPU,
    .epAccess = CY_USBFS_DEV_DRV_USE_8_BITS_DR,
    .epBuffer = NULL,
    .epBufferSize = 0U,
    .dmaConfig[0] = NULL,
    .dmaConfig[1] = NULL,
    .dmaConfig[2] = NULL,
    .dmaConfig[3] = NULL,
    .dmaConfig[4] = NULL,
    .dmaConfig[5] = NULL,
    .dmaConfig[6] = NULL,
    .dmaConfig[7] = NULL,
    .enableLpm = false,
    .intrLevelSel = USB_DEV_INTR_LVL_SEL,
};
#if defined (CY_USING_HAL)
    const cyhal_resource_inst_t USB_DEV_obj = 
    {
        .type = CYHAL_RSC_USB,
        .block_num = 0U,
        .channel_num = 0U,
    };
#endif //defined (CY_USING_HAL)


void init_cycfg_peripherals(void)
{
    Cy_SysClk_PeriphAssignDivider(PCLK_USB_CLOCK_DEV_BRS, CY_SYSCLK_DIV_16_BIT, 0U);
}

void reserve_cycfg_peripherals(void)
{
#if defined (CY_USING_HAL)
    cyhal_hwmgr_reserve(&USB_DEV_obj);
#endif //defined (CY_USING_HAL)
}
