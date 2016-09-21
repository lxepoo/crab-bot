<?php

namespace Crabbot\Core;

use \Exception;

/**
 * 基类
 * 部分摘自Yii2的Object类
 */
class Object {

    //返回类名
    public static function className() {
        return get_called_class();
    }

    //构造函数，自动属性赋值、执行init方法
    public function __construct($config = []) {
        if (!empty($config)) {
            $this->configure($this, $config);
        }
        $this->init();
    }

    //自动属性赋值函数
    protected function configure($object, $properties) {
        foreach ($properties as $name => $value) {
            $object->$name = $value;
        }

        return $object;
    }

    //空方法，用于被继承覆盖
    public function init() {
        
    }

    public function __get($name) {
        $getter = 'get' . $name;
        if (method_exists($this, $getter)) {
            return $this->$getter();
        } elseif (method_exists($this, 'set' . $name)) {
            throw new Exception('Getting write-only property: ' . get_class($this) . '::' . $name);
        } else {
            throw new Exception('Getting unknown property: ' . get_class($this) . '::' . $name);
        }
    }

    public function __set($name, $value) {
        $setter = 'set' . $name;
        if (method_exists($this, $setter)) {
            $this->$setter($value);
        } elseif (method_exists($this, 'get' . $name)) {
            throw new Exception('Setting read-only property: ' . get_class($this) . '::' . $name);
        } else {
            throw new Exception('Setting unknown property: ' . get_class($this) . '::' . $name);
        }
    }

    public function __isset($name) {
        $getter = 'get' . $name;
        if (method_exists($this, $getter)) {
            return $this->$getter() !== null;
        } else {
            return false;
        }
    }

    public function __unset($name) {
        $setter = 'set' . $name;
        if (method_exists($this, $setter)) {
            $this->$setter(null);
        } elseif (method_exists($this, 'get' . $name)) {
            throw new Exception('Unsetting read-only property: ' . get_class($this) . '::' . $name);
        }
    }

    public function __call($name, $params) {
        throw new Exception('Calling unknown method: ' . get_class($this) . "::$name()");
    }

    public function hasProperty($name, $checkVars = true) {
        return $this->canGetProperty($name, $checkVars) || $this->canSetProperty($name, false);
    }

    public function canGetProperty($name, $checkVars = true) {
        return method_exists($this, 'get' . $name) || $checkVars && property_exists($this, $name);
    }

    public function canSetProperty($name, $checkVars = true) {
        return method_exists($this, 'set' . $name) || $checkVars && property_exists($this, $name);
    }

    public function hasMethod($name) {
        return method_exists($this, $name);
    }

    public function toArray() {
        $_arr = is_object($this) ? get_object_vars($this) : $this;
        foreach ($_arr as $key => $val) {
            $val = (is_array($val) || is_object($val)) ? object_to_array($val) : $val;
            $arr[$key] = $val;
        }
        return $arr;
    }

}
