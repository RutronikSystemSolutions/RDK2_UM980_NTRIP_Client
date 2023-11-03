/*******************************************************************************
* File Name: cycfg_peripherals.h
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

#if !defined(CYCFG_PERIPHERALS_H)
#define CYCFG_PERIPHERALS_H

#include "cycfg_notices.h"
#include "cy_usbfs_dev_drv.h"
#include "cy_sysclk.h"
#if defined (CY_USING_HAL)
    #include "cyhal_hwmgr.h"
#endif //defined (CY_USING_HAL)

#if defined(__cplusplus)
extern "C" {
#endif

#define USB_DEV_ENABLED 1U
#define USB_DEV_ACTIVE_ENDPOINTS_MASK 255U
#define USB_DEV_ENDPOINTS_BUFFER_SIZE 512U
#define USB_DEV_ENDPOINTS_ACCESS_TYPE 0U
#define USB_DEV_HW USBFS0
#define USB_DEV_HI_IRQ usb_interrupt_hi_IRQn
#define USB_DEV_MED_IRQ usb_interrupt_med_IRQn
#define USB_DEV_LO_IRQ usb_interrupt_lo_IRQn

extern const cy_stc_usbfs_dev_drv_config_t USB_DEV_config;
#if defined (CY_USING_HAL)
    extern const cyhal_resource_inst_t USB_DEV_obj;
#endif //defined (CY_USING_HAL)

void init_cycfg_peripherals(void);
void reserve_cycfg_peripherals(void);

#if defined(__cplusplus)
}
#endif


#endif /* CYCFG_PERIPHERALS_H */
